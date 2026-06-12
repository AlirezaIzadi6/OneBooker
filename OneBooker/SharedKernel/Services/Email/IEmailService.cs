namespace OneBooker.SharedKernel.Services.Email;

public interface IEmailService
{
    Task SendAsync(SendEmailRequest request);
}