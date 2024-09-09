using MediatR;

namespace DeliveryChannel.BusinessLogic.Orders.Events.OrderCreated;

public record OrderCreatedEvent(string FullName, string Email, long OrderId, string Status) : INotification;