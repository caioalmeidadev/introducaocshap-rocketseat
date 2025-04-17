using ProductClientHub.Exceptions;
using ProductClientHubAPI.Entities;
using ProductClientHubAPI.Infrastructure;
using ProductClientHubAPI.UseCases.Products.Validators;
using ProdutcClientHub.Communication.Requests;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.UseCases.Products.Register;

public class RegisterProductUseCase
{
    public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
    {
        var dbContext = new ProductClientHubDBContext();
        
        Validate(dbContext,clientId,request);
        
        var entity = new Product
        {
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
            clientId = clientId,
        };
        dbContext.Products.Add(entity);
        dbContext.SaveChanges();
        
        return new ResponseShortProductJson
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    private void Validate(ProductClientHubDBContext dbContext,Guid clientId, RequestProductJson request)
    {
        var clientExists = dbContext.Clients.Any(c => c.Id == clientId);
        
        if (!clientExists) throw new NotFoundException("Client not found");
        
        var validator = new ProductValidator();
        
        var result = validator.Validate(request);
        
        if(!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
    }
}