using DeliveryChannel.BusinessLogic.Carts.Models;
using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Carts.Commands.AddItemToCart;

public class AddItemToCartCommandHandler(IRestaurantDbContext context) : IRequestHandler<AddItemToCartCommand, CartDto>
{
    public async Task<CartDto> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(e => e.CartItems)
            .FirstOrDefaultAsync(e => e.Id == request.CartId && !e.IsCheckedOut, cancellationToken);

        if (cart is null)
        {
            cart = new Cart();
            context.Carts.Add(cart);
        }

        var item = await context.Items.FindAsync(request.ItemId);
        if (item is null)
        {
            throw new NotFoundException(nameof(Item), request.ItemId);
        }

        var cartItem = cart.CartItems.FirstOrDefault(e => e.ItemId == request.ItemId);
        if (cartItem is not null)
        {
            cartItem.Quantity += request.Quantity;
        }
        else
        {
            cartItem = new CartItem
            {
                ItemId = request.ItemId,
                Quantity = request.Quantity,
                Price = item.Price
            };

            cart.CartItems.Add(cartItem);
        }

        await context.SaveChangesAsync(cancellationToken);

        return new CartDto
        {
            
        };
    }
}