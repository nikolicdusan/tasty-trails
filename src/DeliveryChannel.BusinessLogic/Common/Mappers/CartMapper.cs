using DeliveryChannel.BusinessLogic.Carts.Models;
using DeliveryChannel.Domain.Entities;

namespace DeliveryChannel.BusinessLogic.Common.Mappers;

public static class CartMapper
{
    public static CartDto ToCartDto(this Cart cart) =>
        new()
        {
            CartId = cart.Id,
            Items = cart.CartItems.Select(e => new CartItemDto
            {
                ItemId = e.ItemId,
                ItemName = e.Item.Name,
                Quantity = e.Quantity,
                Price = e.Price
            }).ToList()
        };
}