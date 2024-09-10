using Microsoft.AspNetCore.Mvc;
using Orders.Application.Restaurants.Queries;

namespace Orders.API.Controllers;

[Route("api/restaurants")]
public class RestaurantController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRestaurants(CancellationToken cancellationToken)
    {
        var getRestaurantsQuery = new GetRestaurantsQuery();
        var restaurants = await Sender.Send(getRestaurantsQuery, cancellationToken);

        return Ok(restaurants);
    }

    [HttpGet("{restaurantId}")]
    public async Task<IActionResult> GetRestaurantById(int restaurantId, CancellationToken cancellationToken)
    {
        var getRestaurantByIdQuery = new GetRestaurantByIdQuery(restaurantId);
        var restaurant = await Sender.Send(getRestaurantByIdQuery, cancellationToken);

        return Ok(restaurant);
    }

    [HttpGet("{restaurantId}/menus")]
    public async Task<IActionResult> GetMenus(int restaurantId, CancellationToken cancellationToken)
    {
        var menus = await Sender.Send(new GetMenusQuery(restaurantId));
        
        return Ok(menus);
    }

    [HttpGet("{restaurantId}/menus/{menuId}")]
    public async Task<IActionResult> GetMenuById(int restaurantId, int menuId, CancellationToken cancellationToken)
    {
        var getMenuByIdQuery = new GetMenuByIdQuery(restaurantId, menuId);
        var menu = await Sender.Send(getMenuByIdQuery, cancellationToken);
        
        return Ok(menu);
    }
}