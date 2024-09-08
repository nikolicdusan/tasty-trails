using System.ComponentModel.DataAnnotations;

namespace DeliveryChannel.Domain.Entities;

public class Restaurant
{
    public long Id { get; set; }
    public required string Name { get; set; }
    [AllowedValues("Serbia", "Iceland")]
    public required string Country { get; set; }
    [AllowedValues("Belgrade", "Novi Sad", "Niš", "Subotica", "Reykjavík", "Kópavogur", "Hafnarfjörður", "Akureyri")]
    public required string City { get; set; }
    public required string AddressLine { get; set; }
    public Menu? Menu { get; set; }
}