namespace Orders.Application.Restaurants.DTOs;

public class MenuItemDto
{
    public int Id { get; set; }
    public int MenuId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
    public bool IsAvailable { get; set; }
}