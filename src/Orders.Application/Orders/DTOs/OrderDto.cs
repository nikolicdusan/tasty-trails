namespace Orders.Application.Orders.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = null!;
    public ICollection<OrderItemDto>? OrderItems { get; set; } = new List<OrderItemDto>();
}