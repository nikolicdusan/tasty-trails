using MediatR;
using OrderManagement.Application.Orders.DTOs;

namespace OrderManagement.Application.Orders.Queries;

public record GetPendingOrdersQuery : IRequest<IEnumerable<OrderDto>>;
