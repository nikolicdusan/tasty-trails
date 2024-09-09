namespace DeliveryChannel.BusinessLogic.MenuItems.Models;

public class MenuItemDto
{
    public long ItemId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
    public string? Description { get; set; }
    public string? Ingredients { get; set; }
}