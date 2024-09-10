namespace Orders.Application.Orders.DTOs;

public class OrderStatusDto
{
    public int OrderId { get; set; }
    public string Status { get; set; } = null!;
    public int EstimatedDeliveryTimeMinutes { get; set; }
}