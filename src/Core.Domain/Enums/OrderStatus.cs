namespace Core.Domain.Enums;

public enum OrderStatus
{
    PendingPayment,
    PendingConfirmation,
    Confirmed,
    Preparing,
    OutForDelivery,
    Delivered,
    Canceled
}