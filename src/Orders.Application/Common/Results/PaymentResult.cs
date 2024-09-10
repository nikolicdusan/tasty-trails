namespace Orders.Application.Common.Results;

public class PaymentResult
{
    public bool IsSuccessful { get; set; }
    public string TransactionId { get; set; } = null!;
    public string? ErrorMessage { get; set; }
}