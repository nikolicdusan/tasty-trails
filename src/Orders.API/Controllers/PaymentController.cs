using Microsoft.AspNetCore.Mvc;
using Orders.Application.Payments.Commands;
using Orders.Application.Payments.DTOs;

namespace Orders.API.Controllers;

/// <summary>
/// API controller for handling payment-related operations.
/// </summary>
[Route("api/payment")]
[Produces("application/json")]
public class PaymentController : ApiControllerBase
{
    /// <summary>
    /// Processes the payment callback from an external payment gateway.
    /// </summary>
    /// <param name="command">The payment creation command, typically triggered by a callback from the payment provider.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the payment operation, including details about the payment transaction.</returns>
    /// <response code="200">Payment successfully processed.</response>
    /// <response code="400">Invalid payment details or processing failure.</response>
    /// <response code="500">An internal server error occurred while processing the payment.</response>
    [HttpPost("callback")]
    [ProducesResponseType(typeof(PaymentResult), 200)]
    public async Task<IActionResult> CreatePayment(CreatePaymentCommand command, CancellationToken cancellationToken)
    {
        var payment = await Sender.Send(command, cancellationToken);
        return Ok(payment);
    }
}
