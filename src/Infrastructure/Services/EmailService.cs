using Core.Services;
using Infrastructure.Configuration;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services;

public class EmailService(ILogger<EmailService> logger, IOptions<SmtpSettings> smtpSettings) : IEmailService
{
    private readonly SmtpSettings _smtpSettings = smtpSettings.Value;

    public async Task SendEmailAsync(string toFullName, string toEmail, string subject, string body,
        CancellationToken cancellationToken)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_smtpSettings.FromName, _smtpSettings.FromEmail));
        message.To.Add(new MailboxAddress(toFullName, toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = body };
        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, cancellationToken: cancellationToken);
            await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password, cancellationToken);
            await client.SendAsync(message, cancellationToken);

            logger.LogInformation("Email sent successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError($"Error sending email: {ex.Message}");
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true, cancellationToken);
            client.Dispose();
        }
    }
}