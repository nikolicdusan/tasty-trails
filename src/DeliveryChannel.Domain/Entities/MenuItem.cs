namespace DeliveryChannel.Domain.Entities;

public class MenuItem
{
    public long MenuId { get; set; }
    public Menu Menu { get; set; } = null!;
    public long ItemId { get; set; }
    public Item Item { get; set; } = null!;
}