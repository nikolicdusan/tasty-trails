namespace Core.Domain.Enums;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Preparing,
    OutForDelivery,
    Delivered,
    Canceled
}