namespace Orders.Application.Restaurants.DTOs;

public class MenuDto
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public TimeOnly AvailableFrom { get; set; }
    public TimeOnly AvailableUntil { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public ICollection<MenuItemDto>? MenuItems { get; set; } = new List<MenuItemDto>();
}