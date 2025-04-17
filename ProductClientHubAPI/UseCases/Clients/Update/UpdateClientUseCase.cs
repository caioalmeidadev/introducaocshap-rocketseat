using ProductClientHub.Exceptions;
using ProductClientHubAPI.Infrastructure;
using ProductClientHubAPI.UseCases.Clients.Register;
using ProductClientHubAPI.UseCases.Clients.Validators;
using ProdutcClientHub.Communication.Requests;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.UseCases.Clients.Update;

public class UpdateClientUseCase
{
    public void Execute(Guid id,RequestClientJson request)
    {
      Validate(request);

      var dbContext = new ProductClientHubDBContext();
      var entity = dbContext.Clients.FirstOrDefault(client => client.Id == id);
    
      if(entity is null) throw new NotFoundException("Client not found");
      
      entity.Name = request.Name;
      entity.Email = request.Email;
      
      dbContext.Clients.Update(entity);
      dbContext.SaveChanges();

    }
    
    private static void Validate(RequestClientJson request)
    {
        var validator = new ClientValidator();
        var result = validator.Validate(request);
        
        if(!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
    }
}