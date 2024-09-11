namespace Core.Services;

public interface IPaymentGatewayService
{
    Task<string> GetPaymentRedirectUrlAsync(string paymentMethod, decimal amount, int orderId);
}