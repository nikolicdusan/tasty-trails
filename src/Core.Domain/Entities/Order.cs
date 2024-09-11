using Core.Domain.Enums;

namespace Core.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? LastUpdatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public int EstimatedDeliveryTimeMinutes { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
}