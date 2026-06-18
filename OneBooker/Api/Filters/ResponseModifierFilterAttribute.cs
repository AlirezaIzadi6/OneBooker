using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using System.Net;

namespace OneBooker.Api.Filters;

public class ResponseModifierFilterAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is not ObjectResult result || result.Value is not IResponse response) return;

        int statusCode = (int)HttpStatusCode.OK;

        if (!response.IsSuccess)
        {
            statusCode = response.ErrorType switch
            {
                ErrorType.BadRequest => (int)HttpStatusCode.BadRequest,
                ErrorType.NotFound => (int)HttpStatusCode.NotFound,
                ErrorType.NotAuthorized => (int)HttpStatusCode.Forbidden,
                ErrorType.NotAuthenticated => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.BadRequest
            };
        }

        context.Result = new ObjectResult(new
        {
            isSuccess = response.IsSuccess,
            message = response.IsSuccess ? null : response.ErrorMessage,
            data = response.Data
        })
        {
            StatusCode = statusCode
        };
    }
}