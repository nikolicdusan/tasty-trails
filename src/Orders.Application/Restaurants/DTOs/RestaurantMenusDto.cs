namespace Orders.Application.Restaurants.DTOs;

public class RestaurantMenusDto
{
    public int RestaurantId { get; set; }
    public ICollection<MenuDto> Menus { get; set; } = new List<MenuDto>();
}