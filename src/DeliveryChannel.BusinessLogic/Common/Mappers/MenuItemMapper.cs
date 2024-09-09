using DeliveryChannel.BusinessLogic.MenuItems.Models;
using DeliveryChannel.Domain.Entities;

namespace DeliveryChannel.BusinessLogic.Common.Mappers;

public static class MenuItemMapper
{
    public static MenuItemDto ToMenuItemDto(this MenuItem menuItem) =>
        new MenuItemDto
        {
            ItemId = menuItem.Item.Id,
            Name = menuItem.Item.Name,
            Price = menuItem.Item.Price,
            Category = menuItem.Item.Category.ToString(),
            Description = menuItem.Item.Description,
            Ingredients = menuItem.Item.Ingredients
        };
}