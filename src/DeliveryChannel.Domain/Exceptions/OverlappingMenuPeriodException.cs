namespace DeliveryChannel.Domain.Exceptions;

public class OverlappingMenuPeriodException : Exception
{
    public OverlappingMenuPeriodException()
        : base()
    {
    }

    public OverlappingMenuPeriodException(string message)
        : base(message)
    {
    }

    public OverlappingMenuPeriodException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public OverlappingMenuPeriodException(DateOnly startDate, DateOnly endDate)
        : base($"A menu with overlapping time period ({startDate} - {endDate}) already exists.")
    {
    }
}