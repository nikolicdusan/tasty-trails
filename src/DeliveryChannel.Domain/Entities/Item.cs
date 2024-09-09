using DeliveryChannel.Domain.Enums;

namespace DeliveryChannel.Domain.Entities;

public class Item
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Ingredients { get; set; }
    public required decimal Price { get; set; }
    public required Category Category { get; set; }
    public ICollection<MenuItem> MenusItems = new List<MenuItem>();
    
}