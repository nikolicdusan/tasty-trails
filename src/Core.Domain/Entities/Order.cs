using Core.Domain.Enums;

namespace Core.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}