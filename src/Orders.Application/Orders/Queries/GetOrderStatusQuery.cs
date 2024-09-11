using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Queries;

public record GetOrderStatusQuery(int OrderId) : IRequest<OrderStatusDto>;