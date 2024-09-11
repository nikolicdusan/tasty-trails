using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Orders.Commands;
using OrderManagement.Application.Orders.DTOs;
using OrderManagement.Application.Orders.Queries;

namespace OrderManagement.API.Controllers;

/// <summary>
/// API controller for managing orders placed by customers.
/// </summary>
[Route("api/orders")]
public class OrderController : ApiControllerBase
{
    /// <summary>
    /// Gets pending orders.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing pending orders.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderDto>), 200)]
    public async Task<IActionResult> GetOrders([FromQuery] int restaurantId, CancellationToken cancellationToken)
    {
        var getOrdersQuery = new GetPendingOrdersQuery();
        var orders = await Sender.Send(getOrdersQuery, cancellationToken);

        return Ok(orders);
    }

    /// <summary>
    /// Gets an order by ID.
    /// </summary>
    /// <param name="orderId">The ID of an order to retrieve.</param>
    /// <returns>Details of the specified order.</returns>
    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(int orderId, CancellationToken cancellationToken)
    {
        var getOrderById = new GetOrderByIdQuery(orderId);
        var order = await Sender.Send(getOrderById, cancellationToken);

        return Ok(order);
    }

    /// <summary>
    /// Updates order status.
    /// </summary>
    /// <param name="orderId">The ID of an order to update.</param>
    /// <param name="command">The update order status command containing new order status.</param>
    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrderStatus(int orderId, UpdateOrderStatusCommand command, CancellationToken cancellationToken)
    {
        if (orderId != command.OrderId)
        {
            return BadRequest("Order ID in the URL does not match the payload data.");
        }
        
        await Sender.Send(command, cancellationToken);

        return NoContent();
    }
}