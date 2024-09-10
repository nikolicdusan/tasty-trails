using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Common.Interfaces;

namespace Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentGatewayService, PaymentGatewayService>();

        return services;
    }
}