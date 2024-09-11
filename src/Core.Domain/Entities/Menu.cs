using Core.Domain.Enums;

namespace Core.Domain.Entities;

public class Menu
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public TimeOnly AvailableFrom { get; set; }
    public TimeOnly AvailableUntil { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public ICollection<MenuItem>? MenuItems { get; set; } = new List<MenuItem>();
}