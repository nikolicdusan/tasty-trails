namespace DeliveryChannel.BusinessLogic.Common.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string toFullName, string toEmail, string subject, string body, CancellationToken cancellationToken = default);
}