using MediatR;

namespace Veiculos.Application.Commands.Auth;

public record LoginCommand(string Login, string Senha) : IRequest<string>;


