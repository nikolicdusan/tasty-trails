using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Orders.Commands.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/orders")]
public class OrdersController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
    {
        var orderId = await Sender.Send(command);

        return Created();
    }
}