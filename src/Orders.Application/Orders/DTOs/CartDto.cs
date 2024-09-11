namespace Orders.Application.Orders.DTOs;

public class CartDto
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<CartItemDto> Items { get; set; } = new List<CartItemDto>();
}