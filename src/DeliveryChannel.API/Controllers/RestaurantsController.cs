using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Menus.Commands.CreateMenu;
using DeliveryChannel.BusinessLogic.Menus.Queries.GetMenus;
using DeliveryChannel.BusinessLogic.Restaurants.Commands.CreateRestaurant;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantById;
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
    public async Task<IActionResult> GetMenus(long restaurantId)
    {
        var menus = await Sender.Send(new GetMenusQuery(restaurantId));

        return Ok(menus);
    }

    [HttpPost("{restaurantId:long}/menus")]
    public async Task<IActionResult> CreateMenu(long restaurantId, CreateMenuCommand command)
    {
        if (restaurantId != command.RestaurantId)
        {
            return BadRequest();
        }

        var menuId = await Sender.Send(command);

        return Ok(menuId);
    }
}