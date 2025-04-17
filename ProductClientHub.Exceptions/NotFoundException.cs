using System.Net;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.Exceptions;

public class NotFoundException:ProductClientHubException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
    }

    public override List<string> GetErrorMessages() => [Message];
    

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}