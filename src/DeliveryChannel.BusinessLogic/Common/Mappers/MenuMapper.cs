using DeliveryChannel.BusinessLogic.Menus.Models;
using DeliveryChannel.BusinessLogic.Restaurants.Models;
using DeliveryChannel.Domain.Entities;

namespace DeliveryChannel.BusinessLogic.Common.Mappers;

public static class MenuMapper
{
    public static MenuDto ToRestaurantMenuDto(this Menu menu) =>
        new MenuDto
        {
            Title = menu.Title,
            StartDate = menu.StartDate,
            EndDate = menu.EndDate
        };
}