using DeliveryChannel.Domain.Enums;

namespace DeliveryChannel.Domain.Entities;

public class Item
{
    public long Id { get; set; }
    public long MenuId { get; set; }
    public required string Name { get; set; }
    public string? Ingredients { get; set; }
    public required decimal Price { get; set; }
    public required Category Category { get; set; }
}