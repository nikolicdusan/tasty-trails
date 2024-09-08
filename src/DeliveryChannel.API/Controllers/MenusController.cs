using DeliveryChannel.API.Common;
using DeliveryChannel.BusinessLogic.Menus.Commands.DeleteMenu;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Controllers;

[Route("api/menus")]
public class MenusController : ApiControllerBase
{
    [HttpDelete("{menuId}")]
    public async Task<IActionResult> DeleteMenu(long menuId)
    {
        await Sender.Send(new DeleteMenuCommand(menuId));

        return NoContent();
    }
}