namespace DeliveryChannel.BusinessLogic.Carts.Models;

public class CartItemDto
{
    public long ItemId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}