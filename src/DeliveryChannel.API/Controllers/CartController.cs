using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Carts.Commands.AddItemToCart;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/cart")]
public class CartController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddToCart(AddItemToCartCommand command)
    {
        var cart = await Sender.Send(command);

        return Ok(cart);
    }
}