using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Commands;

public record RemoveCartItemCommand(int CartId, int ItemId, int Quantity) : IRequest<CartDto>;