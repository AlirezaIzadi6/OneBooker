namespace OneBooker.Shared.Responses.ServiceResponse;

public interface IResponse
{
    bool IsSuccess { get; }

    string ErrorMessage { get; }

    object Data { get; }
}

public interface IResponse<out TResult> : IResponse
{
    new TResult Data { get; }
}