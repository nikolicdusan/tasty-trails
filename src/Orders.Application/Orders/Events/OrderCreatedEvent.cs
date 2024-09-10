using MediatR;

namespace Orders.Application.Orders.Events;

public record OrderCreatedEvent(int OrderId, string Email, string FullName, string Status) : INotification;