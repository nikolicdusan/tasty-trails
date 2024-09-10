namespace Orders.Application.Orders.DTOs;

public class OrderResult
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = null!;
    public string PaymentRedirectUrl { get; set; } = null!;
}