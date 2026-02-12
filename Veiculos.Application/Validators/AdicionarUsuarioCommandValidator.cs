using FluentValidation;
using Veiculos.Application.Commands.Usuarios;

namespace Veiculos.Application.Validators;

public class AdicionarUsuarioCommandValidator : AbstractValidator<AdicionarUsuarioCommand>
{
    public AdicionarUsuarioCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.Login)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.Senha)
            .NotEmpty()
            .MinimumLength(6);
    }
}