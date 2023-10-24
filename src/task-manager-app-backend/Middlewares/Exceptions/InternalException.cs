using System.Net;

namespace task_manager_app_backend.Middlewares.Exceptions;
public class InternalException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public int ErrorCode { get; }

    public InternalException(string message, int errorCode, HttpStatusCode statusCode) : base(message)
    {
        ErrorCode = errorCode;
        StatusCode = statusCode;
    }
}