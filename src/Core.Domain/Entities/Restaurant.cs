using Core.Domain.Enums;

namespace Core.Domain.Entities;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? Address { get; set; }
    public CuisineType CuisineType { get; set; }
    public ICollection<Menu> Menus { get; set; } = new List<Menu>();
}