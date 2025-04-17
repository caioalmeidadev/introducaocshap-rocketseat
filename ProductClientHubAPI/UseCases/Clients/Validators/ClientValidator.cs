using FluentValidation;
using ProdutcClientHub.Communication.Requests;

namespace ProductClientHubAPI.UseCases.Clients.Validators;

public class ClientValidator:AbstractValidator<RequestClientJson>
{
    public ClientValidator()
    {
        RuleFor(client => client.Name).NotEmpty().WithMessage("O nome não pode ser vazio");
        RuleFor(client => client.Email).EmailAddress().WithMessage("O email não é válido");
    }
    
}