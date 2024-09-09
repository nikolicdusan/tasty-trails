namespace DeliveryChannel.Domain.Entities;

public class Customer
{
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}