using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Common.Mappers;
using DeliveryChannel.BusinessLogic.Restaurants.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantMenus;

public class GetRestaurantMenusQueryHandler(IRestaurantDbContext context) : IRequestHandler<GetRestaurantMenusQuery, IEnumerable<RestaurantMenuDto>>
{
    public async Task<IEnumerable<RestaurantMenuDto>> Handle(GetRestaurantMenusQuery request, CancellationToken cancellationToken)
    {
        var menus = await context.Menus
            .Where(e => e.RestaurantId == request.RestaurantId)
            .ToListAsync(cancellationToken);

        return menus.Select(menu => menu.ToRestaurantMenuDto());
    }
}