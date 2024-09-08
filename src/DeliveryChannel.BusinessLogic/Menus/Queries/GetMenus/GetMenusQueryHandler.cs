using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Common.Mappers;
using DeliveryChannel.BusinessLogic.Menus.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Menus.Queries.GetMenus;

public class GetMenusQueryHandler(IRestaurantDbContext context) : IRequestHandler<GetMenusQuery, IEnumerable<MenuDto>>
{
    public async Task<IEnumerable<MenuDto>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
    {
        var menus = await context.Menus
            .Where(e => e.RestaurantId == request.RestaurantId)
            .ToListAsync(cancellationToken);

        return menus.Select(menu => menu.ToMenuDto());
    }
}