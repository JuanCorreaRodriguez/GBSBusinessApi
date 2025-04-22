namespace GlamBeautyApi.ErrorHandler;

public static class ResultExtensions
{
    public static IResult GlobalResult<T>(
        this T result,
        string title,
        string? detail,
        int? statusCode
    )
    {
        return Results.Problem(
            statusCode: statusCode,
            title: title,
            detail: detail,
            extensions: new Dictionary<string, object?>
            {
                { "data", result }
            }
        );
    }

    public static IResult ErrorResult<T>(
        this Result<T> result,
        string title,
        string? detail,
        int? statusCode
    )
    {
        return Results.Problem(
            statusCode: statusCode,
            title: title,
            detail: detail,
            extensions: new Dictionary<string, object?>
            {
                { "data", new[] { result.Error } }
            }
        );
    }
}