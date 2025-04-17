using ProductClientHub.Exceptions;
using ProductClientHubAPI.Infrastructure;

namespace ProductClientHubAPI.UseCases.Products.Delete;

public class DeleteProductUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new ProductClientHubDBContext();
        
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);

        if (product is null) throw new NotFoundException("Product not found");

        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
    }
}