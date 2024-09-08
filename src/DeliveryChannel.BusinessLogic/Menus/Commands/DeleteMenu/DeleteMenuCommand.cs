using MediatR;

namespace DeliveryChannel.BusinessLogic.Menus.Commands.DeleteMenu;

public record DeleteMenuCommand(long Id) : IRequest;