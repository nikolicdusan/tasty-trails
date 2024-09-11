using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using Core.Services;
using MediatR;

namespace OrderManagement.Application.Orders.Events;

public class OrderUpdatedEventHandler(IApplicationDbContext context, IEmailService emailService) : INotificationHandler<OrderUpdatedEvent>
{
    public async Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .FindAsync(new object?[] { notification.OrderId }, cancellationToken);

        if (order is null)
        {
            throw new NotFoundException(nameof(Order), notification.OrderId);
        }

        var fullName = $"{order.FirstName} {order.LastName}";
        var email = order.Email!;
        const string subject = "Tasty Trails - Your Order Status Changed";
        var body = $"""
                        <h1>Order Status Changed</h1>
                        <br/>
                        Dear {fullName},
                        <br/>
                        Your order (ID: {order.Id}) is now <b>{Enum.GetName(typeof(OrderStatus), order.Status)}</b>
                        <br/>
                        <br/>
                        Thank you for your patience.
                    """;

        await emailService.SendEmailAsync(fullName, email, subject, body, cancellationToken);
    }
}