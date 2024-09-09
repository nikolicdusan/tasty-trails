using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Restaurants.Commands.CreateRestaurant;
using DeliveryChannel.BusinessLogic.Restaurants.Commands.DeleteRestaurant;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantById;
using DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurants;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/restaurants")]
public class RestaurantController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var restaurants = await Sender.Send(new GetRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpGet("{restaurantId}")]
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

    [HttpDelete("{restaurantId}")]
    public async Task<IActionResult> DeleteRestaurant(long restaurantId)
    {
        await Sender.Send(new DeleteRestaurantCommand(restaurantId));

        return NoContent();
    }
}