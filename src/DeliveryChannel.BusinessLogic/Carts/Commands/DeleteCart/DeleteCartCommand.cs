using MediatR;

namespace DeliveryChannel.BusinessLogic.Carts.Commands.DeleteCart;

public record DeleteCartCommand(Guid CartId) : IRequest;