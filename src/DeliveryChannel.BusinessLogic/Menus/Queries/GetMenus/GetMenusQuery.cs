using DeliveryChannel.BusinessLogic.Menus.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Menus.Queries.GetMenus;

public record GetMenusQuery(long RestaurantId) : IRequest<IEnumerable<MenuDto>>;