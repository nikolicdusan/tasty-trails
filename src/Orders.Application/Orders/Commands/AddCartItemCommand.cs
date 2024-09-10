using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Commands;

public record AddCartItemCommand(int CartId, int ItemId, int Quantity) : IRequest<CartDto>;