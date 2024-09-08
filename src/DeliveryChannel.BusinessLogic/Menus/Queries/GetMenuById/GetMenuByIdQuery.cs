using DeliveryChannel.BusinessLogic.Menus.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Menus.Queries.GetMenuById;

public record GetMenuByIdQuery(long Id) : IRequest<MenuDto>;