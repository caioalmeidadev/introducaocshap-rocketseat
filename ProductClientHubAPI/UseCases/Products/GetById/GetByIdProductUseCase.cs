using ProductClientHub.Exceptions;
using ProductClientHubAPI.Infrastructure;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.UseCases.Products.GetById;

public class GetByIdProductUseCase
{
    public ResponseShortProductJson Execute(Guid id)
    {
        var dbContext = new ProductClientHubDBContext();
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) throw new NotFoundException("Product not found");
        return new ResponseShortProductJson
        {
            Id = product.Id,
            Name = product.Name,
        };
    }
    
    
}