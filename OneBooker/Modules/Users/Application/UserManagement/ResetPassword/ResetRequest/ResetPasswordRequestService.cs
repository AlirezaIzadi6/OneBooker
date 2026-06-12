using Microsoft.Extensions.Options;
using OneBooker.Modules.Users.Application.Common.Extentions;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using OneBooker.SharedKernel.Services.Email;
using OneBooker.SharedKernel.Services.Globalization;
using System.Globalization;
using System.Text;

namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public class ResetPasswordRequestService(
    IUserRepository users,
    ITokenRepository tokens,
    IGlobalizationService globalizationService,
    ITokenGenerator tokenGenerator,
    IHashGenerator hashGenerator,
    IEmailService emailService,
    IOptions<ResetPasswordSettings> resetPasswordConfig) : IResetPasswordRequestService, IScopedService
{
    private static readonly CompositeFormat EmailBodyFormat = CompositeFormat.Parse(EmailConstants.Body);

    public async Task<Response<bool>> RequestReset(ResetPasswordRequest request)
    {
        User user = await users.GetByEmailAsync(request.Email);
        if (user is null)
        {
            return Response<bool>.NotFound(globalizationService.NotFoundError(nameof(User)));
        }

        await tokens.DeleteExistingTokensFor(user.Id);
        ResetPasswordSettings settings = resetPasswordConfig.Value;

        string token = tokenGenerator.GenerateRandomToken(40);
        string hashedToken = hashGenerator.HashString(token);
        var newToken = new ResetPasswordToken
        {
            UserId = user.Id,
            HashedToken = hashedToken,
            ExpirationTime = DateTime.UtcNow.AddMinutes(settings.ExpirationMinutes),
        };

        // TODO: Add a job for removing expired tokens.
        await tokens.Create(newToken);

        string resetPasswordUrl = string.Format(
            CultureInfo.InvariantCulture,
            settings.ResetPasswordUrl,
            token);
        string body = string.Format(
            CultureInfo.InvariantCulture,
            EmailBodyFormat,
            user.FirstName,
            settings.ExpirationMinutes,
            resetPasswordUrl);
        var emailRequest = new SendEmailRequest
        {
            Recipients = [request.Email],
            subject = EmailConstants.Subject,
            Body = body,
        };

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

        // Disable warning because not awaiting this call is intentional and in order not to block the main request.
        emailService.SendAsync(emailRequest);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

        return Response<bool>.Success(true);
    }
}