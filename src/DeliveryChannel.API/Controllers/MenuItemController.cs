using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.MenuItems.Queries.GetMenuItems;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/restaurants/{restaurantId}/menus/{menuId}/menu-items")]
public class MenuItemController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMenuItems(long restaurantId, long menuId)
    {
        var menuItems = await Sender.Send(new GetMenuItemsQuery(restaurantId, menuId));

        return Ok(menuItems);
    }
}