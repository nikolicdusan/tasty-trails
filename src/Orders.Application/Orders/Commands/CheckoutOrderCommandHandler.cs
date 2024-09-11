using System.Security.Cryptography;
using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using Core.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Orders.DTOs;
using Orders.Application.Orders.Events;

namespace Orders.Application.Orders.Commands;

public class CheckoutOrderCommandHandler(IApplicationDbContext context, IPublisher publisher, IPaymentGatewayService paymentGatewayService) :
    IRequestHandler<CheckoutOrderCommand, OrderResult>
{
    public async Task<OrderResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == request.CartId && !c.IsCheckedOut,
                cancellationToken);

        if (cart is null || cart.CartItems.Count == 0)
        {
            throw new NotFoundException(nameof(Cart), request.CartId);
        }

        var order = new Order
        {
            CartId = request.CartId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            TotalAmount = cart.CartItems.Sum(ci => ci.Quantity * ci.Price),
            Status = OrderStatus.PendingPayment,
            EstimatedDeliveryTimeMinutes = RandomNumberGenerator.GetInt32(10, 60)
        };
        context.Orders.Add(order);

        foreach (var cartItem in cart.CartItems)
        {
            var orderItem = new OrderItem
            {
                MenuItemId = cartItem.MenuItemId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price
            };
            order.OrderItems?.Add(orderItem);
        }

        cart.IsCheckedOut = true;

        await context.SaveChangesAsync(cancellationToken);

        var orderCreatedEvent = new OrderCreatedEvent(order.Id, order.Email, $"{order.FirstName} {order.LastName}", order.Status.ToString());
        await publisher.Publish(orderCreatedEvent, cancellationToken);

        var paymentRedirectUrl = await paymentGatewayService.GetPaymentRedirectUrlAsync(request.PaymentMethod, order.TotalAmount, order.Id);

        return new OrderResult
        {
            Id = order.Id,
            Status = order.Status.ToString(),
            TotalAmount = order.TotalAmount,
            CreatedAt = order.CreatedAt,
            PaymentRedirectUrl = paymentRedirectUrl
        };
    }
}