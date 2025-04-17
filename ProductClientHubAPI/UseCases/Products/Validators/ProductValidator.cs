using FluentValidation;
using ProdutcClientHub.Communication.Requests;

namespace ProductClientHubAPI.UseCases.Products.Validators;

public class ProductValidator:AbstractValidator<RequestProductJson>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Brand).NotEmpty().WithMessage("Brand is required");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price is required");
    }
    
}