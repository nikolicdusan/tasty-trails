using DeliveryChannel.Domain.Enums;

namespace DeliveryChannel.Domain.Entities;

public class Order
{
    public long Id { get; set; }
    public long? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public required OrderStatus Status { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required decimal Subtotal { get; set; }
    public required decimal? Discount { get; set; }
    public required decimal Total { get; set; }
}