using Core.Domain.Enums;

namespace Core.Domain.Entities;

public class MenuItem
{
    public int Id { get; set; }
    public int MenuId { get; set; }
    public Menu Menu { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public bool IsAvailable { get; set; }
}