using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.ChangePassword;

public interface IChangePasswordService
{
    Task<Response<bool>> ChangePassword(ChangePasswordRequest request);
}