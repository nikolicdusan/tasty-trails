namespace DeliveryChannel.Domain.Entities;

public class CartItem
{
    public long Id { get; set; }
    public Guid CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    public long ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}