namespace DeliveryChannel.Domain.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public long? CustomerId { get; set; }
    public bool IsCheckedOut { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}