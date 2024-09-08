using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Menus.Commands.CreateMenu;
using DeliveryChannel.BusinessLogic.Menus.Commands.DeleteMenu;
using DeliveryChannel.BusinessLogic.Menus.Queries.GetMenuById;
using DeliveryChannel.BusinessLogic.Menus.Queries.GetMenus;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/restaurants")]
public class MenusController : ApiControllerBase
{
    [HttpGet("{restaurantId}/menus")]
    public async Task<IActionResult> GetMenus(long restaurantId, CancellationToken cancellationToken)
    {
        var menus = await Sender.Send(new GetMenusQuery(restaurantId), cancellationToken);

        return Ok(menus);
    }

    [HttpGet("{menuId}")]
    public async Task<IActionResult> GetMenuById(long menuId, CancellationToken cancellationToken)
    {
        var menu = await Sender.Send(new GetMenuByIdQuery(menuId), cancellationToken);

        return Ok(menu);
    }

    [HttpPost("{restaurantId}/menus")]
    public async Task<IActionResult> CreateMenu(long restaurantId, CreateMenuCommand command, CancellationToken cancellationToken)
    {
        if (restaurantId != command.RestaurantId)
        {
            return BadRequest();
        }

        var menuId = await Sender.Send(command, cancellationToken);

        return Ok(menuId);
    }

    [HttpDelete("{menuId}")]
    public async Task<IActionResult> DeleteMenu(long menuId, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteMenuCommand(menuId), cancellationToken);

        return NoContent();
    }
}