using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Restaurants.DTOs;

namespace Orders.Application.Restaurants.Queries;

public class GetMenusQueryHandler(IApplicationDbContext context) : IRequestHandler<GetMenusQuery, RestaurantMenusDto>
{
    public async Task<RestaurantMenusDto> Handle(GetMenusQuery request, CancellationToken cancellationToken)
    {
        var menus = await context.Menus
            .Where(m => m.RestaurantId == request.RestaurantId)
            .ToListAsync(cancellationToken);

        return new RestaurantMenusDto
        {
            RestaurantId = request.RestaurantId,
            Menus = menus.Select(m => new MenuDto
            {
                Id = m.Id,
                RestaurantId = m.RestaurantId,
                Name = m.Name,
                Description = m.Description,
                AvailableFrom = m.AvailableFrom,
                AvailableUntil = m.AvailableUntil,
                CreatedAt = m.CreatedAt,
                LastUpdatedAt = m.LastUpdatedAt,
                MenuItems = null
            }).ToList()
        };
    }
}