namespace DeliveryChannel.BusinessLogic.MenuItems.Models;

public class MenuItemListDto(ICollection<MenuItemDto> items)
{
    public IEnumerable<MenuItemDto> Items { get; set; } = items;
}