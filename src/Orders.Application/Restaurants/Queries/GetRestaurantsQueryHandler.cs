using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Restaurants.DTOs;

namespace Orders.Application.Restaurants.Queries;

public class GetRestaurantsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
    {
        var restaurants = await context.Restaurants
            .ToListAsync(cancellationToken);

        return restaurants.Select(restaurant => new RestaurantDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Country = restaurant.Country,
            City = restaurant.City,
            Address = restaurant.Address ?? string.Empty,
            CuisineType = restaurant.CuisineType.ToString()
        });
    }
}