namespace DeliveryChannel.Domain.Entities;

public class OrderItem
{
    public long Id { get; set; }
    public long ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}