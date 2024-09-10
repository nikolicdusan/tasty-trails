using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Commands;

public class RemoveCartItemCommandHandler(IApplicationDbContext context) : IRequestHandler<RemoveCartItemCommand, CartDto>
{
    public async Task<CartDto> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == request.CartId && !c.IsCheckedOut,
                cancellationToken);

        if (cart is null || cart.CartItems.Count == 0)
        {
            throw new NotFoundException(nameof(Cart), request.CartId);
        }

        var menuItem = await context.MenuItems.FindAsync(new object?[] { request.ItemId }, cancellationToken);
        if (menuItem is null)
        {
            throw new NotFoundException(nameof(MenuItem), request.ItemId);
        }

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.MenuItemId == request.ItemId);
        if (cartItem is not null)
        {
            RemoveCartItem(request, cartItem);
            AdjustCartTotalAmount(request, cart, menuItem);
        }

        await context.SaveChangesAsync(cancellationToken);
        
        return new CartDto
        {
            Id = cart.Id,
            TotalAmount = cart.TotalAmount,
            Items = cart.CartItems.Select(ci => new CartItemDto
            {
                Id = ci.Id,
                Name = ci.MenuItem.Name,
                Price = ci.Price,
                Quantity = ci.Quantity
            }).ToList()
        };
    }

    private void RemoveCartItem(RemoveCartItemCommand request, CartItem cartItem)
    {
        if (request.Quantity > cartItem.Quantity)
        {
            throw new InvalidOperationException();
        }

        cartItem.Quantity -= request.Quantity;

        if (cartItem.Quantity == 0)
        {
            context.CartItems.Remove(cartItem);
        }
    }

    private static void AdjustCartTotalAmount(RemoveCartItemCommand request, Cart cart, MenuItem menuItem)
    {
        cart.TotalAmount -= request.Quantity * menuItem.Price;
    }
}