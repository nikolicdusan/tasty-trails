using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Common.Mappers;
using DeliveryChannel.BusinessLogic.Orders.Commands.Models;
using DeliveryChannel.Domain.Entities;
using DeliveryChannel.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler(IRestaurantDbContext context) : IRequestHandler<CreateOrderCommand, OrderDto>
{
    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(e => e.CartItems)
            .FirstOrDefaultAsync(e => e.Id == request.CartId && !e.IsCheckedOut,
                cancellationToken);

        if (cart is null || cart.CartItems.Count == 0)
        {
            throw new NotFoundException(nameof(Cart), request.CartId);
        }

        var customer = await context.Customers
            .SingleOrDefaultAsync(e => e.Id == request.CustomerId,
                cancellationToken);

        var discountTiers = await context.DiscountTiers
            .ToListAsync(cancellationToken);

        var discount = CalculateDiscount(customer, discountTiers);
        var subtotal = cart.CartItems.Sum(e => e.Quantity * e.Price);

        var order = new Order
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            Subtotal = subtotal,
            Discount = discount,
            Total = subtotal - discount
        };

        context.Orders.Add(order);

        cart.IsCheckedOut = true;

        await context.SaveChangesAsync(cancellationToken);

        return order.ToOrderDto();
    }

    private static int CalculateDiscount(Customer? customer, IEnumerable<DiscountTier> discountTiers)
    {
        if (customer is null || customer.Orders.Count == 0)
        {
            return 0;
        }

        return discountTiers
            .Where(e => customer.Orders.Count >= e.MinimumOrderAmount)
            .Max()!
            .DiscountAmount;
    }
}