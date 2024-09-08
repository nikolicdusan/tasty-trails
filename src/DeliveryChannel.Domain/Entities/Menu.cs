namespace DeliveryChannel.Domain.Entities;

public class Menu
{
    public long Id { get; set; }
    public long RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public string? Title { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public ICollection<MenuItem> Items { get; set; } = new List<MenuItem>();
}