using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Carts.Commands.AddItemToCart;
using DeliveryChannel.BusinessLogic.Carts.Commands.DeleteCart;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/carts")]
public class CartController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddToCart(AddItemToCartCommand command)
    {
        var cart = await Sender.Send(command);

        return Ok(cart);
    }

    [HttpDelete("{cartId}")]
    public async Task<IActionResult> DeleteCart(Guid cartId)
    {
        await Sender.Send(new DeleteCartCommand(cartId));

        return NoContent();
    }
}