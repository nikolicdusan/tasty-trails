namespace Core.Domain.Entities;

public class Cart
{
    public int Id { get; set; }
    public bool IsCheckedOut { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}