using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Restaurants.Models;
using DeliveryChannel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurants;

public class GetRestaurantsQueryHandler(IRestaurantDbContext context) : IRequestHandler<GetRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
    {
        var restaurants = await context.Restaurants
            .ToListAsync(cancellationToken);
        var r = new Restaurant
        {
            Id = 1,
            Name = "Test",
            Country = "Test",
            City = "Test",
            AddressLine = "Test"
        };
        return restaurants.Select(restaurant => new RestaurantDto
        {
            Name = restaurant.Name,
            Country = restaurant.Country,
            City = restaurant.City,
            AddressLine = restaurant.AddressLine
        });
    }
}