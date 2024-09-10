using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Queries;

public class GetOrderStatusQueryHandler(IApplicationDbContext context) : IRequestHandler<GetOrderStatusQuery, OrderStatusDto>
{
    public async Task<OrderStatusDto> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .FindAsync(new object?[] { request.OrderId }, cancellationToken);

        if (order is null)
        {
            throw new NotFoundException(nameof(Order), request.OrderId);
        }

        return new OrderStatusDto
        {
            OrderId = order.Id,
            Status = order.Status.ToString(),
            EstimatedDeliveryTimeMinutes = order.EstimatedDeliveryTimeMinutes
        };
    }
}