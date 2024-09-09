using DeliveryChannel.Domain.Entities;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.Infrastructure.Data;

public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options), IRestaurantDbContext
{
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await base.SaveChangesAsync(cancellationToken);
}