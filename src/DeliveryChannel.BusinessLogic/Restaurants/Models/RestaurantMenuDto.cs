namespace DeliveryChannel.BusinessLogic.Restaurants.Models;

public class RestaurantMenuDto
{
    public string? Title { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}