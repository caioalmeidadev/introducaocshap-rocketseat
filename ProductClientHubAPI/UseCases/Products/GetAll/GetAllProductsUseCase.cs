using ProductClientHubAPI.Infrastructure;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.UseCases.Products.GetAll;

public class GetAllProductsUseCase
{
    public ResponseListProductsJson Execute()
    {
        var dbContext = new ProductClientHubDBContext();
        var products = dbContext.Products.ToList();
        return new ResponseListProductsJson
        {
            Products = products.Select(p => new ResponseShortProductJson
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList()
        };
    }
}