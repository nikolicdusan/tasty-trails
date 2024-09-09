namespace DeliveryChannel.BusinessLogic.MenuItems.Models;

public class MenuItemListDto(ICollection<MenuItemDto> items)
{
    public ICollection<MenuItemDto> Items { get; set; } = items;
}