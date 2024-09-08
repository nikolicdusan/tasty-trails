using MediatR;

namespace DeliveryChannel.BusinessLogic.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    long RestaurantId,
    string Title,
    DateOnly StartDate,
    DateOnly EndDate) : IRequest<long>;