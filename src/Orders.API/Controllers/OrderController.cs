using Microsoft.AspNetCore.Mvc;
using Orders.Application.Orders.Commands;

namespace Orders.API.Controllers;

[Route("api/orders")]
public class OrderController : ApiControllerBase
{
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
}