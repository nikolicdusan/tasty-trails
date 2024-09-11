using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Enums;

public enum OrderStatus
{
    [Display(Name = "Pending Payment")] 
    PendingPayment,
    [Display(Name = "Pending Confirmation")]
    PendingConfirmation,
    Confirmed,
    Preparing,
    [Display(Name = "Out for Delivery")] 
    OutForDelivery,
    Delivered,
    Canceled
}