namespace DeliveryChannel.Domain.Exceptions;

public class OverlappingMenuPeriodException(DateOnly startDate, DateOnly endDate) : Exception(
    $"A menu with overlapping time period ({startDate} - {endDate}) already exists.");