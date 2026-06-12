using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using System.Text.Json.Serialization;

namespace OneBooker.Api.Filters;

public class ResponseModifierFilterAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is not ObjectResult result || result.Value is not IResponse response) return;

        context.Result = response.IsSuccess
            ? new OkObjectResult(new OkResult(response.Data))
            : new BadRequestObjectResult(new ErrorResult(response.ErrorMessage));
    }
}

public record OkResult(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    object Data,
    [property: JsonPropertyOrder(-1)] string Message = "Ok");

public record ErrorResult(string Message);