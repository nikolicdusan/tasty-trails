using Core.Services;
using MediatR;

namespace Orders.Application.Orders.Events;

public class OrderCreatedEventHandler(IEmailService emailService) : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        const string subject = "Tasty Trails Order Confirmation";
        var body = $"""
                    <h2>Dear {notification.FullName}, <br/>Thank you for your order!</h2>
                    <br/>
                    <br/>
                    <b>Order details:</b>
                    <br/>
                    Order ID: {notification.OrderId}
                    <br/>
                    Status: {notification.Status}
                    """;

        await emailService.SendEmailAsync(notification.FullName, notification.Email, subject, body, cancellationToken);
    }
}