namespace Orders.Application.Common.Interfaces;

public interface IPaymentGatewayService
{
    Task<string> GetPaymentRedirectUrlAsync(string paymentMethod, decimal amount, int orderId);
}