using DeliveryChannel.BusinessLogic.Carts.Models;
using DeliveryChannel.Domain.Entities;

namespace DeliveryChannel.BusinessLogic.Common.Mappers;

public static class CartMapper
{
    public static CartDto ToCartDto(this Cart cart) =>
        new CartDto
        {
            Items = cart.CartItems.Select(e => new CartItemDto
            {
                ItemId = e.ItemId,
                Quantity = e.Quantity,
                Price = e.Price
            })
        };
}