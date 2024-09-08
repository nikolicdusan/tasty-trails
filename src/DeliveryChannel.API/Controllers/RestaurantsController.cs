using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Restaurants.Commands.CreateRestaurant;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantById;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantMenus;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurants;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/restaurants")]
public class RestaurantsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var restaurants = await Sender.Send(new GetRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpGet("{restaurantId:long}")]
    public async Task<IActionResult> GetRestaurantById(long restaurantId)
    {
        var restaurant = await Sender.Send(new GetRestaurantByIdQuery(restaurantId));

        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        var restaurantId = await Sender.Send(command);

        return Ok(restaurantId);
    }

    [HttpGet("{restaurantId:long}/menus")]
    public async Task<IActionResult> GetRestaurantMenus(long restaurantId)
    {
        var menus = await Sender.Send(new GetRestaurantMenusQuery(restaurantId));

        return Ok(menus);
    }
}