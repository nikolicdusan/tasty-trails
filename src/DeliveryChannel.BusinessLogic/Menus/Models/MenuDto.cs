namespace DeliveryChannel.BusinessLogic.Menus.Models;

public class MenuDto
{
    public string? Title { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}