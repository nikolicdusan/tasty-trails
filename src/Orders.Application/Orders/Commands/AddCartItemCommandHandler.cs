using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Commands;

public class AddCartItemCommandHandler(IApplicationDbContext context) : IRequestHandler<AddCartItemCommand, CartDto>
{
    public async Task<CartDto> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == request.CartId && !c.IsCheckedOut,
                cancellationToken);

        if (cart is null)
        {
            cart = new Cart
            {
                IsCheckedOut = false
            };
            context.Carts.Add(cart);
        }

        var menuItem = await context.MenuItems
            .FindAsync(new object?[] { request.ItemId },
                cancellationToken);
        if (menuItem is null)
        {
            throw new NotFoundException(nameof(MenuItem), request.ItemId);
        }

        var cartItem = cart.CartItems
            .FirstOrDefault(ci => ci.MenuItemId == request.ItemId);

        if (cartItem is not null)
        {
            cartItem.Quantity += request.Quantity;
        }
        else
        {
            cartItem = new CartItem
            {
                MenuItemId = request.ItemId,
                Quantity = request.Quantity,
                Price = menuItem.Price
            };

            cart.CartItems.Add(cartItem);
        }

        cart.TotalAmount += request.Quantity * menuItem.Price;

        await context.SaveChangesAsync(cancellationToken);

        return new CartDto
        {
            Id = cart.Id,
            TotalAmount = cart.TotalAmount,
            Items = cart.CartItems.Select(ci => new CartItemDto
            {
                Id = ci.Id,
                Name = ci.MenuItem.Name,
                Quantity = ci.Quantity,
                Price = ci.Price
            }).ToList()
        };
    }
}