using ProductClientHub.Exceptions;
using ProductClientHubAPI.Infrastructure;
using ProductClientHubAPI.UseCases.Products.Validators;
using ProdutcClientHub.Communication.Requests;

namespace ProductClientHubAPI.UseCases.Products.Update;

public class UpdateProductUseCase
{
    public void Execute(Guid id,RequestProductJson request)
    {
        Validate(request);

        var dbContext = new ProductClientHubDBContext();
        var entity = dbContext.Products.FirstOrDefault(p => p.Id == id);
    
        if(entity is null) throw new NotFoundException("Product not found");
      
        
        entity.Name = request.Name;
        entity.Brand = request.Brand;
        entity.Price = request.Price;
      
        dbContext.Products.Update(entity);
        dbContext.SaveChanges();
    }

    private void Validate(RequestProductJson request)
    {
        
        var validator = new ProductValidator();
        
        var result = validator.Validate(request);
        
        if(!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
    }
}