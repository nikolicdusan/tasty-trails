namespace DeliveryChannel.Domain.Entities;

public class OrderItem
{
    public required long OrderId { get; set; }
    public required Order Order { get; set; }
    public required long MenuItemId { get; set; }
    public required Item Item { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
}