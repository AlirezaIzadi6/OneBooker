using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public interface IResetPasswordRequestService
{
    Task<Response<bool>> RequestReset(ResetPasswordRequest request);
}