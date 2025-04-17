using ProductClientHub.Exceptions;
using ProductClientHubAPI.Infrastructure;

namespace ProductClientHubAPI.UseCases.Clients.Delete;

public class DeleteClienteUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new ProductClientHubDBContext();
        var client = dbContext.Clients.FirstOrDefault(c => c.Id == id);
        if (client is null) throw new NotFoundException("Client not found");
        dbContext.Clients.Remove(client);
        dbContext.SaveChanges();
    }
}