namespace AscentBackend.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; private set; }
        public HttpException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class NotFoundException : HttpException
    {
        public NotFoundException(string message) : base(StatusCodes.Status404NotFound, message) { }
    }

    public class ConflictException : HttpException
    {
        public ConflictException(string message) : base(StatusCodes.Status409Conflict, message) { }        
    }

    public class UnauthorizedException : HttpException
    {
        public UnauthorizedException(string message) : base(StatusCodes.Status401Unauthorized, message) { }
    }

    public class ForbiddenException : HttpException
    {
        public ForbiddenException(string message) : base(StatusCodes.Status403Forbidden, message) { }
    }

    public class MethodNotAllowedException : HttpException
    {
        public MethodNotAllowedException(string message) : base(StatusCodes.Status405MethodNotAllowed, message) { }
    }

    public class UnprocessableContentException : HttpException
    {
        public UnprocessableContentException(string message) : base(StatusCodes.Status422UnprocessableEntity, message) { }
    }
}
