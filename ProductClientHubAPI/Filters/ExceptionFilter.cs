using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Exceptions.ExceptionBase;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.Filters;

public class ExceptionFilter:IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ProductClientHubException productClientHubException)
        {
            context.HttpContext.Response.StatusCode = (int)productClientHubException.GetHttpStatusCode();
            context.Result = new ObjectResult(new ResponseErrorJson(productClientHubException.GetErrorMessages()));
        }
        else
        {
           ThrowUnkownException(context); 
        }
    }

    private static void ThrowUnkownException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("ERRO DESCONHECIDO"));
    }
}