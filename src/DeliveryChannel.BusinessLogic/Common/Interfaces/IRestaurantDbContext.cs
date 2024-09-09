using DeliveryChannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Common.Interfaces;

public interface IRestaurantDbContext
{
    DbSet<Cart> Carts { get; }
    DbSet<CartItem> CartItems { get; }
    DbSet<Customer> Customers { get; }
    DbSet<DiscountTier> DiscountTiers { get; }
    DbSet<Item> Items { get; }
    DbSet<Menu> Menus { get; }
    DbSet<MenuItem> MenuItems { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<Restaurant> Restaurants { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}