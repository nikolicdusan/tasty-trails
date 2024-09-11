namespace Core.Services;

public interface IEmailService
{
    Task SendEmailAsync(string toFullName, string toEmail, string subject, string body, CancellationToken cancellationToken = default);
}