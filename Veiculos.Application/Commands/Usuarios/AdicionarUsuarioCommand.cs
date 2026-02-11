using MediatR;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Commands.Usuarios;

public record AdicionarUsuarioCommand(
    string Nome,
    string Login,
    string Senha
) : IRequest<Usuario>;
