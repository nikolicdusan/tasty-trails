using Core.Domain.Entities;
using Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class DatabaseInitializer(ApplicationDbContext context, ILogger<DatabaseInitializer> logger)
{
    public async Task SeedDatabaseAsync(CancellationToken cancellationToken)
    {
        await InitializeDatabaseAsync(cancellationToken);
        await SeedAsync(cancellationToken);
    }

    private async Task InitializeDatabaseAsync(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Initializing the database.");

            await context.Database.EnsureCreatedAsync(cancellationToken);

            if (context.Database.IsRelational())
            {
                logger.LogInformation("Applying migrations.");
                await context.Database.MigrateAsync(cancellationToken);
            }

            logger.LogInformation("Database successfully initialized.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occured while attempting to initialize the database.");
            throw;
        }
    }

    private async Task SeedAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Seeding the database.");

        SeedRestaurants();
        SeedMenus();
        SeedMenuItems();

        await context.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Finished seeding the database.");
    }

    private void SeedRestaurants()
    {
        var restaurants = new List<Restaurant>
        {
            new Restaurant
            {
                Id = 1,
                Name = "Sarajevski Ćevap kod Dakca",
                Country = "Serbia",
                City = "Novi Sad",
                Address = "Braće Popović BB",
                CuisineType = CuisineType.Domestic
            },
            new Restaurant
            {
                Id = 2,
                Name = "Tramontana",
                Country = "Serbia",
                City = "Novi Sad",
                Address = "Grčkoškolska 7",
                CuisineType = CuisineType.Italian
            }
        };

        foreach (var restaurant in restaurants.Where(restaurant => !context.Restaurants.Any(x => x.Name == restaurant.Name || x.Id == restaurant.Id)))
        {
            context.Restaurants.Add(restaurant);
        }
    }

    private void SeedMenus()
    {
        var menus = new List<Menu>()
        {
            new Menu
            {
                Id = 1,
                RestaurantId = 1,
                Name = "Jela sa roštilja",
                Description = "Jela sa roštilja od najfinijeg mlevenog goveđeg i junećeg mesa",
                AvailableFrom = TimeOnly.FromTimeSpan(new TimeSpan(8, 0, 0)),
                AvailableUntil = TimeOnly.FromTimeSpan(new TimeSpan(23, 0, 0)),
                CreatedAt = DateTime.Today
            },
            new Menu
            {
                Id = 2,
                RestaurantId = 2,
                Name = "Pizza",
                Description = "Pizza na napuljski način",
                AvailableFrom = TimeOnly.FromTimeSpan(new TimeSpan(8, 0, 0)),
                AvailableUntil = TimeOnly.FromTimeSpan(new TimeSpan(23, 0, 0)),
                CreatedAt = DateTime.Today
            }
        };

        foreach (var menu in menus.Where(menu => !context.Menus.Any(x => x.Name == menu.Name && x.RestaurantId == menu.RestaurantId)))
        {
            context.Menus.Add(menu);
        }
    }

    private void SeedMenuItems()
    {
        var menuItems = new List<MenuItem>()
        {
            new MenuItem
            {
                Id = 1,
                MenuId = 1,
                Name = "10 ćevapa",
                Description = "10 ćevapa od goveđeg i junećeg mlevenog mesa u lepinji",
                Price = 660,
                Category = Category.MainCourse,
                IsAvailable = true
            },
            new MenuItem
            {
                Id = 2,
                MenuId = 1,
                Name = "Sudžuka kobasica",
                Description = "Kobasica - ljuta i dva pruta",
                Price = 530,
                Category = Category.MainCourse,
                IsAvailable = true
            },
            new MenuItem
            {
                Id = 3,
                MenuId = 2,
                Name = "Margherita antica",
                Description =
                    "San marzano pelat, mozzarela fior di late, svež bosiljak, grana padano parmesan, caputo super nuvola (brašno organskog porekla)",
                Price = 1250,
                Category = Category.MainCourse,
                IsAvailable = true
            }
        };

        foreach (var menuItem in menuItems.Where(menuItem => !context.MenuItems.Any(x => x.Name == menuItem.Name && x.MenuId == menuItem.MenuId)))
        {
            context.MenuItems.Add(menuItem);
        }
    }
}