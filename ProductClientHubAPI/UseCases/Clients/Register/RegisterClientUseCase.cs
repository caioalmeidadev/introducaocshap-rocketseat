using ProductClientHub.Exceptions;
using ProductClientHubAPI.Entities;
using ProductClientHubAPI.Infrastructure;
using ProductClientHubAPI.UseCases.Clients.Validators;
using ProdutcClientHub.Communication.Requests;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(RequestClientJson request)
    {
        Validate(request);
        var dbContext = new ProductClientHubDBContext();

        var entity = new Client
        {
            Name = request.Name,
            Email = request.Email
        };

        dbContext.Clients.Add(entity);
        dbContext.SaveChanges();
        
        return new ResponseClientJson
        {
            Id = entity.Id,
            Nome = entity.Name,
            Email = entity.Email
        };
    }

    private static void Validate(RequestClientJson request)
    {
        var validator = new ClientValidator();
        var result = validator.Validate(request);
        
        if(!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
    }
}