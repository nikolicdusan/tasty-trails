namespace DeliveryChannel.BusinessLogic.Carts.Models;

public class CartDto
{
    public Guid CartId { get; set; }
    public IEnumerable<CartItemDto> Items { get; set; } = new List<CartItemDto>();
}