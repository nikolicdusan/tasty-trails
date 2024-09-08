using DeliveryChannel.Infrastructure.Data;
using DeliveryChannel.Service.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryChannel.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("RestaurantDb"),
                cfg => cfg.MigrationsAssembly(typeof(RestaurantDbContext).Assembly.FullName)));
        services.AddScoped<IRestaurantDbContext>(provider => provider.GetRequiredService<RestaurantDbContext>());

        return services;
    }
}