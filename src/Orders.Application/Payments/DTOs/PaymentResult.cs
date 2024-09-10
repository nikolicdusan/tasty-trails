namespace Orders.Application.Payments.DTOs;

public class PaymentResult
{
    public int OrderId { get; set; }
    public string Status { get; set; } = null!;
    public DateTime PaymentDate { get; set; }
}