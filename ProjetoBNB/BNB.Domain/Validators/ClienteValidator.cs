using BNB.Domain.Entities;
using FluentValidation;

namespace BNB.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(cliente => cliente.Email)
                .EmailAddress().WithMessage("E-mail inválido.");
        }
    }
}
