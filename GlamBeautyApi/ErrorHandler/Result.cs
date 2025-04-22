using GlamBeautyApi.Errors;

namespace GlamBeautyApi.ErrorHandler;

public class Result<T>
{
    private Result(bool isSuccess, T value, Error error)
    {
        // if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
        // throw new ArgumentException($"Invalid error: {error}");

        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public bool IsSuccess { get; }

    public T Value { get; set; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, null);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(false, default, error);
    }
}