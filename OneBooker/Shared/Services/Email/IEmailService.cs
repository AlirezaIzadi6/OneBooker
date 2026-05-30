namespace OneBooker.Shared.Services.Email;

public interface IEmailService
{
    Task SendAsync(SendEmailRequest request);
}