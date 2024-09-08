using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Restaurants.Commands.CreateRestaurant;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantById;
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

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetRestaurantById(long id)
    {
        var restaurant = await Sender.Send(new GetRestaurantByIdQuery(id));

        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        var restaurantId = await Sender.Send(command);

        return Ok(restaurantId);
    }
}