using Microsoft.AspNetCore.Mvc;
using Orders.Application.Orders.Commands;
using Orders.Application.Orders.DTOs;
using Orders.Application.Orders.Queries;

namespace Orders.API.Controllers;

/// <summary>
/// API controller for handling order and cart-related operations.
/// </summary>
[Route("api/orders")]
[Produces("application/json")]
public class OrderController : ApiControllerBase
{
    /// <summary>
    /// Submits a checkout order.
    /// </summary>
    /// <param name="command">The checkout order command containing order details.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>An <see cref="IActionResult"/> representing the outcome of the checkout operation, typically containing order details or errors.</returns>
    /// <response code="200">Order successfully checked out.</response>
    /// <response code="400">Invalid order data or processing failure.</response>
    [HttpPost]
    [ProducesResponseType(typeof(OrderResult), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CheckoutOrder(CheckoutOrderCommand command, CancellationToken cancellationToken)
    {
        var orderResult = await Sender.Send(command, cancellationToken);
        return Ok(orderResult);
    }

    /// <summary>
    /// Adds an item to the user's cart.
    /// </summary>
    /// <param name="command">The add item to cart command, containing the item details.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>An <see cref="IActionResult"/> representing the updated cart.</returns>
    /// <response code="200">Item successfully added to the cart.</response>
    /// <response code="400">Invalid item data or cart modification failure.</response>
    [HttpPost("cart/items")]
    [ProducesResponseType(typeof(CartDto), 200)]
    [ProducesResponseType(404)] 
    public async Task<IActionResult> AddItemToCart(AddCartItemCommand command, CancellationToken cancellationToken)
    {
        var cart = await Sender.Send(command, cancellationToken);
        return Ok(cart);
    }

    /// <summary>
    /// Removes an item from the user's cart.
    /// </summary>
    /// <param name="itemId">The ID of the item to be removed.</param>
    /// <param name="command">The remove item from cart command containing the item ID to remove.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>An <see cref="IActionResult"/> representing the updated cart.</returns>
    /// <response code="200">Item successfully removed from the cart.</response>
    /// <response code="400">Invalid item data or mismatch between request item ID and command item ID.</response>
    [HttpDelete("cart/items/{itemId}")]
    [ProducesResponseType(typeof(CartDto), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> RemoveCartItem(int itemId, RemoveCartItemCommand command, CancellationToken cancellationToken)
    {
        if (itemId != command.ItemId)
        {
            return BadRequest("Item ID in the URL does not match the command data.");
        }

        var cart = await Sender.Send(command, cancellationToken);
        return Ok(cart);
    }

    /// <summary>
    /// Gets the status of a specific order.
    /// </summary>
    /// <param name="orderId">The ID of the order to retrieve the status of.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>An <see cref="IActionResult"/> containing the current status of the order.</returns>
    /// <response code="200">Order status successfully retrieved.</response>
    /// <response code="404">Order not found.</response>
    [HttpGet("{orderId}/status")]
    [ProducesResponseType(typeof(OrderStatusDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetOrderStatus(int orderId, CancellationToken cancellationToken)
    {
        var getOrderStatusQuery = new GetOrderStatusQuery(orderId);
        var order = await Sender.Send(getOrderStatusQuery, cancellationToken);
        return Ok(order);
    }
}
