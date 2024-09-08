using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Restaurants.Commands.CreateRestaurant;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurants;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

public class RestaurantsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var restaurants = await Sender.Send(new GetRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        var restaurantId = await Sender.Send(command);

        return Ok(restaurantId);
    }
}