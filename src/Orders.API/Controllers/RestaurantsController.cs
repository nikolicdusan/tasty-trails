using Microsoft.AspNetCore.Mvc;
using Orders.Application.Restaurants.Queries;

namespace Orders.API.Controllers;

[Route("api/restaurants")]
public class RestaurantsController : ApiControllerBase
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
}