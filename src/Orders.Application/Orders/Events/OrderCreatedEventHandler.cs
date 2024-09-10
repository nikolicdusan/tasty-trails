using Core.Services;
using MediatR;

namespace Orders.Application.Orders.Events;

public class OrderCreatedEventHandler(IEmailService emailService) : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        const string subject = "Tasty Trails Order Confirmation";
        var body = $"""
                    <h1>Thank you for your order!</h1>
                    <br/>
                    <br/>
                    Order ID: {notification.OrderId}
                    <br/>
                    Status: {notification.Status}
                    """;

        await emailService.SendEmailAsync(notification.FullName, notification.Email, subject, body, cancellationToken);
    }
}