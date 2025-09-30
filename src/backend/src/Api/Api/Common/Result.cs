namespace Api.Common;

public class Result<T>
{
    public bool IsSuccess { get; init; }
    public string? Error { get; init; }
    public T? Data { get; init; }
    public IDictionary<string, string[]>? Errors { get; init; }

    public static Result<T> Success(T value) => new Result<T>
    {
        IsSuccess = true,
        Data = value
    };

    public static Result<T> Failure(string message, IDictionary<string, string[]>? errors = null) => new Result<T>
    {
        IsSuccess = false,
        Error = message,
        Errors = errors
    };
}


