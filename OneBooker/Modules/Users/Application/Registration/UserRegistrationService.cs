using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.Modules.Users.Domain.UserManagement.Enums;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.Responses.ValidationResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.Registration;

/// <summary>
/// The service responsible for registerring new users.
/// </summary>
public class UserRegistrationService(IUserRepository users, IPasswordHashService hashService, IGlobalizationService globalizationService) : IUserRegistrationService, IScopedService
{
    /// <summary>
    /// A very simple implementation of user registration.
    /// </summary>
    /// <param name="request"><see cref="RegistrationRequest"/> object containing registration request info.</param>
    /// <returns>true if registration is successful, otherwise error message.</returns>
    public async Task<Response<int>> RegisterUser(RegistrationRequest request)
    {
        ValidationResult uniquenessValidationResult = await CheckUserUniqueness(request);

        if (!uniquenessValidationResult.IsValid)
        {
            return Response<int>.Fail(uniquenessValidationResult.ErrorMessage);
        }

        string hashedPassword = await hashService.Hash(request.Password);

        var newUser = new User
        {
            Username = request.UserName,
            NormalizedUsername = request.UserName.ToUpper(CultureInfo.InvariantCulture),
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpper(CultureInfo.InvariantCulture),
            PasswordHash = hashedPassword,
            FirstName = request.FirstName,
            LastName = request.LastName,
            NationalCode = request.NationalCode,
            Role = UserRole.Normal,
        };

        await users.CreateUser(newUser);

        return Response<int>.Success(newUser.Id);
    }

    private async Task<ValidationResult> CheckUserUniqueness(RegistrationRequest request)
    {
        bool isUsernameDuplicate = await users.IsUsernameDuplicate(request.UserName.ToUpper(CultureInfo.InvariantCulture));
        if (isUsernameDuplicate)
        {
            return ValidationResult.Fail(GetDuplicationErrorMessage("username"));
        }

        bool isEmailDuplicate = await users.IsEmailDuplicate(request.Email.ToUpper(CultureInfo.InvariantCulture));
        if (isEmailDuplicate)
        {
            return ValidationResult.Fail(GetDuplicationErrorMessage("email"));
        }

        bool isNationalCodeDuplicate = await users.IsNationalCodeDuplicate(request.NationalCode);
        if (isNationalCodeDuplicate)
        {
            return ValidationResult.Fail(GetDuplicationErrorMessage("national code"));
        }

        return ValidationResult.Success;
    }

    private string GetDuplicationErrorMessage(string duplicateField)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            globalizationService.Localize(Messages.DuplicateItem),
            duplicateField);
    }
}