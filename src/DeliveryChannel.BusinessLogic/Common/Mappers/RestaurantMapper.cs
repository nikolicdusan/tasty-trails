using DeliveryChannel.BusinessLogic.Restaurants.Models;
using DeliveryChannel.Domain.Entities;

namespace DeliveryChannel.BusinessLogic.Common.Mappers;

public static class RestaurantMapper
{
    public static RestaurantDto ToRestaurantDto(this Restaurant restaurant) =>
        new RestaurantDto
        {
            Name = restaurant.Name,
            Country = restaurant.Country,
            City = restaurant.City,
            AddressLine = restaurant.AddressLine
        };
}