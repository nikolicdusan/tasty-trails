using Microsoft.AspNetCore.Mvc;
using Orders.Application.Restaurants.DTOs;
using Orders.Application.Restaurants.Queries;

namespace Orders.API.Controllers;

/// <summary>
/// API controller for managing restaurant-related operations.
/// </summary>
[Route("api/restaurants")]
[Produces("application/json")]
public class RestaurantController : ApiControllerBase
{
    /// <summary>
    /// Retrieves a list of all available restaurants.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>A list of restaurants.</returns>
    /// <response code="200">Successfully retrieved the list of restaurants.</response>
    /// <response code="500">An internal server error occurred while fetching restaurants.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RestaurantDto>), 200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetRestaurants(CancellationToken cancellationToken)
    {
        var getRestaurantsQuery = new GetRestaurantsQuery();
        var restaurants = await Sender.Send(getRestaurantsQuery, cancellationToken);
        return Ok(restaurants);
    }

    /// <summary>
    /// Retrieves details of a specific restaurant by its ID.
    /// </summary>
    /// <param name="restaurantId">The ID of the restaurant to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>Details of the specified restaurant.</returns>
    /// <response code="200">Successfully retrieved the restaurant details.</response>
    /// <response code="404">The restaurant with the specified ID was not found.</response>
    /// <response code="500">An internal server error occurred while fetching the restaurant.</response>
    [HttpGet("{restaurantId}")]
    [ProducesResponseType(typeof(RestaurantDto), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetRestaurantById(int restaurantId, CancellationToken cancellationToken)
    {
        var getRestaurantByIdQuery = new GetRestaurantByIdQuery(restaurantId);
        var restaurant = await Sender.Send(getRestaurantByIdQuery, cancellationToken);
        return Ok(restaurant);
    }

    /// <summary>
    /// Retrieves all menus for a specific restaurant.
    /// </summary>
    /// <param name="restaurantId">The ID of the restaurant whose menus should be retrieved.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>A list of menus for the specified restaurant.</returns>
    /// <response code="200">Successfully retrieved the menus for the restaurant.</response>
    /// <response code="404">The restaurant with the specified ID was not found or has no menus.</response>
    /// <response code="500">An internal server error occurred while fetching the menus.</response>
    [HttpGet("{restaurantId}/menus")]
    [ProducesResponseType(typeof(RestaurantMenusDto), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetMenus(int restaurantId, CancellationToken cancellationToken)
    {
        var menus = await Sender.Send(new GetMenusQuery(restaurantId), cancellationToken);
        return Ok(menus);
    }

    /// <summary>
    /// Retrieves details of a specific menu by its ID for a specific restaurant.
    /// </summary>
    /// <param name="restaurantId">The ID of the restaurant.</param>
    /// <param name="menuId">The ID of the menu to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>Details of the specified menu.</returns>
    /// <response code="200">Successfully retrieved the menu details.</response>
    /// <response code="404">The restaurant or menu with the specified ID was not found.</response>
    /// <response code="500">An internal server error occurred while fetching the menu.</response>
    [HttpGet("{restaurantId}/menus/{menuId}")]
    [ProducesResponseType(typeof(MenuDto), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetMenuById(int restaurantId, int menuId, CancellationToken cancellationToken)
    {
        var getMenuByIdQuery = new GetMenuByIdQuery(restaurantId, menuId);
        var menu = await Sender.Send(getMenuByIdQuery, cancellationToken);
        return Ok(menu);
    }
}