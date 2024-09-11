using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using OrderManagement.Application.Orders.DTOs;

namespace OrderManagement.Application.Orders.Queries;

public class GetOrderByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .FindAsync(new object?[] { request.OrderId }, cancellationToken);
        if (order is null)
        {
            throw new NotFoundException(nameof(Order), request.OrderId);
        }

        return new OrderDto
        {
            OrderId = order.Id,
            FirstName = order.FirstName,
            LastName = order.LastName,
            Email = order.Email,
            Address = order.Address,
            PhoneNumber = order.PhoneNumber,
            TotalAmount = order.TotalAmount,
            Status = order.Status.ToString(),
            CreatedAt = order.CreatedAt,
            LastUpdatedAt = order.LastUpdatedAt
        };
    }
}