using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetSubmission;

public interface IResetPasswordSubmissionService
{
    Task<Response<bool>> SubmitResetRequest(ResetPasswordSubmissionRequest request);
}