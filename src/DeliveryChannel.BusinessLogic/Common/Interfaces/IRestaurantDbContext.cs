using DeliveryChannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Common.Interfaces;

public interface IRestaurantDbContext
{
    DbSet<Item> Items { get; }
    DbSet<Menu> Menus { get; }
    DbSet<MenuItem> MenuItems { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<Restaurant> Restaurants { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}