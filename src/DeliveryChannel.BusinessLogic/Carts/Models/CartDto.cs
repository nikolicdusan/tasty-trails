namespace DeliveryChannel.BusinessLogic.Carts.Models;

public class CartDto
{
    public IEnumerable<CartItemDto> Items = new List<CartItemDto>();
}