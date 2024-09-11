using MediatR;

namespace OrderManagement.Application.Orders.Commands;

public record UpdateOrderStatusCommand(int OrderId, string Status) : IRequest;
