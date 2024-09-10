using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Orders.Commands;
using Orders.Application.Orders.Queries;

namespace Orders.API.Controllers;

[Route("api/orders")]
public class OrderController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CheckoutOrder(CheckoutOrderCommand command, CancellationToken cancellationToken)
    {
        var orderResult = await Sender.Send(command, cancellationToken);

        return Ok(orderResult);
    }

    [HttpPost("cart/items")]
    public async Task<IActionResult> AddItemToCart(AddCartItemCommand command, CancellationToken cancellationToken)
    {
        var cart = await Sender.Send(command, cancellationToken);

        return Ok(cart);
    }

    [HttpDelete("cart/items/{itemId}")]
    public async Task<IActionResult> RemoveCartItem(int itemId, RemoveCartItemCommand command, CancellationToken cancellationToken)
    {
        if (itemId != command.ItemId)
        {
            return BadRequest();
        }

        var cart = await Sender.Send(command, cancellationToken);

        return Ok(cart);
    }

    [HttpGet("{orderId}/status")]
    public async Task<IActionResult> GetOrderStatus(int orderId, CancellationToken cancellationToken)
    {
        var getOrderStatusQuery = new GetOrderStatusQuery(orderId);
        var order = await Sender.Send(getOrderStatusQuery, cancellationToken);

        return Ok(order);
    }
}