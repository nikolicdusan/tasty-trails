using DeliveryChannel.BusinessLogic.MenuItems.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.MenuItems.Queries.GetMenuItems;

public record GetMenuItemsQuery(long RestaurantId, long MenuId) : IRequest<MenuItemListDto>;