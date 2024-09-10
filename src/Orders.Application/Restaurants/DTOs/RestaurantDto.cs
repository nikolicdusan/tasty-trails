namespace Orders.Application.Restaurants.DTOs;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string CuisineType { get; set; } = null!;
}