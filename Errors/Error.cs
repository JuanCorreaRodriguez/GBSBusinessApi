using GBSApi.ErrorHandler;

namespace GBSApi.Errors
{
    public sealed record Error(string Code, int Status)
    {
        public static readonly Error None =
            new(string.Empty, StatusCodes.Status200OK);

        public static implicit operator Result<Error>(Error error)
        {
            return Result<Error>.Failure(error);
        }
    }

    public static class StatusErrors
    {
        public static readonly Error Conflict = new("Conflict", StatusCodes.Status409Conflict);
        public static readonly Error DtoError = new("DtoError", StatusCodes.Status400BadRequest);
        public static readonly Error NotFound = new("NotFound", StatusCodes.Status404NotFound);
        public static readonly Error BadRequest = new("BadRequest", StatusCodes.Status400BadRequest);
        public static readonly Error Ok = new("Ok", StatusCodes.Status200OK);
        public static readonly Error Created = new("Created", StatusCodes.Status201Created);
        public static readonly Error Forbidden = new("Forbidden", StatusCodes.Status403Forbidden);
        public static readonly Error NoContent = new("NoContent", StatusCodes.Status204NoContent);
        public static readonly Error Unauthorized = new("Unauthorized", StatusCodes.Status401Unauthorized);
    }
}