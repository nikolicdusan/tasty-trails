using MediatR;
using OrderManagement.Application.Orders.DTOs;

namespace OrderManagement.Application.Orders.Queries;

public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto>;
