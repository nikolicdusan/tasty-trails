using DeliveryChannel.BusinessLogic.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryChannel.BusinessLogic;

public static class ServiceConfiguration
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(IRestaurantDbContext).Assembly));

        return services;
    }
}