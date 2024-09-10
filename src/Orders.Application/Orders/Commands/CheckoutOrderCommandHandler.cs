using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Commands;

public class CheckoutOrderCommandHandler(IApplicationDbContext context) : IRequestHandler<CheckoutOrderCommand, OrderDto>
{
    public async Task<OrderDto> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
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
            CreatedAt = DateTime.UtcNow,
            TotalAmount = cart.CartItems.Sum(ci => ci.Quantity * ci.Price)
        };

        context.Orders.Add(order);
        cart.IsCheckedOut = true;

        await context.SaveChangesAsync(cancellationToken);

        return new OrderDto
        {
            Id = order.Id,
            Status = order.Status.ToString(),
            TotalAmount = order.TotalAmount,
            CreatedAt = order.CreatedAt
        };
    }
}