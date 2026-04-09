namespace OneBooker.Shared.Responses;

public record Response<TResult>
{
    public bool IsSuccess { get; }

    public string? ErrorMessage { get; }

    public TResult? Data { get; }

    private Response(bool isSuccess, string? errorMessage, TResult? data)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        Data = data;
    }

    public static Response<TResult> Success(TResult data)
    {
        return new Response<TResult>(true, null, data);
    }

    public static Response<TResult> Fail(string errorMessage)
    {
        return new Response<TResult>(false, errorMessage, default);
    }
}