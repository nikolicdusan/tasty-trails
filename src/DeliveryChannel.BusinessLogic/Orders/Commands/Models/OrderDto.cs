namespace DeliveryChannel.BusinessLogic.Orders.Commands.Models;

public class OrderDto
{
    public long Id { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; } = null!;
}