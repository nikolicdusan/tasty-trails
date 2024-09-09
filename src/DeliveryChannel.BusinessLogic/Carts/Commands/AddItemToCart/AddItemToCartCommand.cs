using DeliveryChannel.BusinessLogic.Carts.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Carts.Commands.AddItemToCart;

public record AddItemToCartCommand(
    Guid? CartId,
    long ItemId,
    int Quantity) : IRequest<CartDto>;