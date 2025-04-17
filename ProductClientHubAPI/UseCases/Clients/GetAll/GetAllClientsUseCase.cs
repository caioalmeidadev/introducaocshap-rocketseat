using ProductClientHubAPI.Infrastructure;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.UseCases.Clients.GetAll;

public class GetAllClientsUseCase
{
    public  ResponseListClientsJson Execute()
    {
        var dbContext = new ProductClientHubDBContext();
        var clients = dbContext.Clients.ToList();

        return new ResponseListClientsJson
        {
            Clients = clients.Select(c => new ResponseClientJson
            {
                Nome = c.Name,
                Email = c.Email
            }).ToList()
        };
    }
}