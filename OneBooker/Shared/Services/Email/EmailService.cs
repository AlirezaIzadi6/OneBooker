using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Shared.Services.Email;

public class EmailService(IOptions<EmailSettings> emailConfig, ILogger<EmailService> logger) : IEmailService, ISingletonService
{
    public async Task SendAsync(SendEmailRequest request)
    {
        EmailSettings settings = emailConfig.Value;
        MimeMessage email = CreateEmail(request, settings);

        try
        {
            // TODO: handle failures in case of sudden shutdown or application crash.
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(settings.SmtpServer, settings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(settings.Username, settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            // TODO: Use LoggerMessage + a more informing error.
            logger.LogError(e, "Sending email failed.");
        }
    }

    private static MimeMessage CreateEmail(SendEmailRequest request, EmailSettings settings)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(settings.SenderName, settings.SenderEmail));

        var recipientMails = request.Recipients.Select(MailboxAddress.Parse);
        email.To.AddRange(recipientMails);
        email.Subject = request.subject;
        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = request.Body
        };
        email.Body = bodyBuilder.ToMessageBody();
        return email;
    }
}