using System.Net;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.Exceptions;

public class ErrorOnValidationException:ProductClientHubException
{
    private readonly List<string> _errors;
    public ErrorOnValidationException(List<string> errorsMessages) : base(string.Empty)
    {
        _errors = errorsMessages;
    }

    public override List<string> GetErrorMessages() => _errors;
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}