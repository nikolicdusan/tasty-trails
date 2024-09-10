using Core.Services;

namespace Infrastructure.Services;

public class PaymentGatewayService : IPaymentGatewayService
{
    public Task<string> GetPaymentRedirectUrlAsync(string paymentMethod, decimal amount, int orderId)
    {
        // Generate fake redirect URL for payment provider
        return Task.FromResult($"https://paymentgateway.com/checkout?amount={amount}&orderId={orderId}");
    }
}