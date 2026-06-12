namespace OneBooker.SharedKernel.Responses.ServiceResponse;

public record Response<TResult> : IResponse<TResult>
{
    protected Response(bool isSuccess, string errorMessage, TResult data, ErrorType? errorType = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        ErrorType = errorType;
        Data = data;
    }

    public ErrorType? ErrorType { get; }

    public bool IsSuccess { get; }

    public string ErrorMessage { get; }

    public TResult Data { get; }

    object IResponse.Data => Data;

    public static Response<TResult> Success(TResult data)
    {
        return new Response<TResult>(true, null, data);
    }

    public static Response<TResult> Fail(string errorMessage)
    {
        return new Response<TResult>(false, errorMessage, default, ServiceResponse.ErrorType.BadRequest);
    }

    public static Response<TResult> NotAuthorized(string errorMessage)
    {
        return new Response<TResult>(false, errorMessage, default, ServiceResponse.ErrorType.NotAuthorized);
    }

    public static Response<TResult> NotAuthenticated(string errorMessage)
    {
        return new Response<TResult>(false, errorMessage, default, ServiceResponse.ErrorType.NotAuthenticated);
    }

    public static Response<TResult> NotFound(string errorMessage)
    {
        return new Response<TResult>(false, errorMessage, default, ServiceResponse.ErrorType.NotFound);
    }
}