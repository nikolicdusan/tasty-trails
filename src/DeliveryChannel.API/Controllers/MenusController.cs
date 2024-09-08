using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Menus.Commands.CreateMenu;
using DeliveryChannel.BusinessLogic.Menus.Commands.DeleteMenu;
using DeliveryChannel.BusinessLogic.Menus.Queries.GetMenus;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/restaurants")]
public class MenusController : ApiControllerBase
{
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
    
    [HttpDelete("{menuId}")]
    public async Task<IActionResult> DeleteMenu(long menuId)
    {
        await Sender.Send(new DeleteMenuCommand(menuId));

        return NoContent();
    }
}