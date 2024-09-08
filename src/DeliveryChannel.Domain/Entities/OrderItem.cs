namespace DeliveryChannel.Domain.Entities;

public class OrderItem
{
    public required long OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public required long ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
}