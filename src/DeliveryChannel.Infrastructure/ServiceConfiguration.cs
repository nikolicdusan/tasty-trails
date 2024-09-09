using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.Infrastructure.Configuration;
using DeliveryChannel.Infrastructure.Data;
using DeliveryChannel.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryChannel.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

        services.AddDbContext<RestaurantDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("RestaurantDb"),
                cfg => cfg.MigrationsAssembly(typeof(RestaurantDbContext).Assembly.FullName)));
        
        services.AddScoped<IRestaurantDbContext>(provider => provider.GetRequiredService<RestaurantDbContext>());
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}