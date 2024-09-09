namespace DeliveryChannel.BusinessLogic.Common.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string fullName, string fromEmail, string toEmail, string subject, string body, CancellationToken cancellationToken);
}