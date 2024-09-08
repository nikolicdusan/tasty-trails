namespace DeliveryChannel.Domain.Entities;

public class Restaurant
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string AddressLine { get; set; }
    public Menu? Menu { get; set; }
}