using Core.Domain.Enums;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Orders.DTOs;

namespace OrderManagement.Application.Orders.Queries;

public class GetPendingOrdersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPendingOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetPendingOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await context.Orders
            .Where(e => e.Status == OrderStatus.PendingConfirmation)
            .ToListAsync(cancellationToken);

        return orders.Select(order => new OrderDto
        {
            OrderId = order.Id,
            FirstName = order.FirstName,
            LastName = order.LastName,
            Email = order.Email,
            Address = order.Address,
            PhoneNumber = order.PhoneNumber,
            Status = order.Status.ToString(),
            TotalAmount = order.TotalAmount,
            CreatedAt = order.CreatedAt,
            LastUpdatedAt = order.LastUpdatedAt
        });
    }
}