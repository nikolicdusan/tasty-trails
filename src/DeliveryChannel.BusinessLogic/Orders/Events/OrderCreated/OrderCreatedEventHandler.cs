using DeliveryChannel.BusinessLogic.Common.Interfaces;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Orders.Events.OrderCreated;

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