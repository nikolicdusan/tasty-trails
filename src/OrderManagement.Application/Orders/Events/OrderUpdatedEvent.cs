using MediatR;

namespace OrderManagement.Application.Orders.Events;

public record OrderUpdatedEvent(int OrderId) : INotification;