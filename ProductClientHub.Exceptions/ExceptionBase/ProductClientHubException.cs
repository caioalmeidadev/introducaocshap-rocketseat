using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase;

public abstract class ProductClientHubException:SystemException
{
    public ProductClientHubException(string errorMessage):base(errorMessage)
    {
        
    }
    
    
    public abstract List<string> GetErrorMessages();

    public abstract HttpStatusCode GetHttpStatusCode();
}