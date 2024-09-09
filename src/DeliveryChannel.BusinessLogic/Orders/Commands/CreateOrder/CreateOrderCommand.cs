using DeliveryChannel.BusinessLogic.Orders.Commands.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid CartId,
    long CustomerId,
    string FirstName,
    string LastName,
    string Email,
    string Address,
    string PhoneNumber) : IRequest<OrderDto>;