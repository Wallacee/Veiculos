using FluentValidation;
using Veiculos.Application.Commands.Veiculos;

namespace Veiculos.Application.Validators;

public class AdicionarVeiculoCommandValidator : AbstractValidator<AdicionarVeiculoCommand>
{
    public AdicionarVeiculoCommandValidator()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Modelo)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Marca)
            .IsInEnum();
    }
}