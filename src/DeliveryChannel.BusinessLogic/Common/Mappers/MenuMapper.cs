using DeliveryChannel.BusinessLogic.Restaurants.Models;
using DeliveryChannel.Domain.Entities;

namespace DeliveryChannel.BusinessLogic.Common.Mappers;

public static class MenuMapper
{
    public static RestaurantMenuDto ToRestaurantMenuDto(this Menu menu) =>
        new RestaurantMenuDto
        {
            Title = menu.Title,
            StartDate = menu.StartDate,
            EndDate = menu.EndDate
        };
}