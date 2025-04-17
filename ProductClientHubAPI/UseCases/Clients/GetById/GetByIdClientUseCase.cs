using ProductClientHub.Exceptions;
using ProductClientHubAPI.Infrastructure;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.UseCases.Clients.GetById;

public class GetByIdClientUseCase
{
    public ResponseClientJson Execute(Guid id)
    {
        var dbContext = new ProductClientHubDBContext();
        var client = dbContext.Clients.FirstOrDefault(c => c.Id == id);
        if (client is null) throw new NotFoundException("Client not found");
        
        return new ResponseClientJson
        {
            Id = client.Id,
            Email = client.Email,
            Nome = client.Name
        } ;
    }
}