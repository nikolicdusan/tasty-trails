using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Common.Mappers;
using DeliveryChannel.BusinessLogic.MenuItems.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.MenuItems.Queries.GetMenuItems;

public class GetMenuItemsQueryHandler(IRestaurantDbContext context) : IRequestHandler<GetMenuItemsQuery, MenuItemListDto>
{
    public async Task<MenuItemListDto> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        var menuItems = await context.MenuItems
            .Include(e => e.Item)
            .Where(e => e.Menu.RestaurantId == request.RestaurantId)
            .Where(e => e.MenuId == request.MenuId)
            .Select(e => e.ToMenuItemDto())
            .ToListAsync(cancellationToken);

        return new MenuItemListDto(menuItems);
    }
}