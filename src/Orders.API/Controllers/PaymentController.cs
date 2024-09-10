using Microsoft.AspNetCore.Mvc;
using Orders.Application.Payments.Commands;

namespace Orders.API.Controllers;

[Microsoft.AspNetCore.Components.Route("api/payment")]
public class PaymentController : ApiControllerBase
{
    [HttpPost("callback")]
    public async Task<IActionResult> CreatePayment(CreatePaymentCommand command, CancellationToken cancellationToken)
    {
        var payment = await Sender.Send(command, cancellationToken);

        return Ok(payment);
    }
}