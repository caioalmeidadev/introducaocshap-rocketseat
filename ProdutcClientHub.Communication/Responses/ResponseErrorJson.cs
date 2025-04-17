using ProductClientHub.Exceptions.ExceptionBase;

namespace ProdutcClientHub.Communication.Responses;

public class ResponseErrorJson
{
    public ResponseErrorJson(string message)
    {
        Errors = [message];
    }

    public ResponseErrorJson(List<string> messages)
    {
        Errors = messages;
    }
    public List<string> Errors { get; private set; }
}