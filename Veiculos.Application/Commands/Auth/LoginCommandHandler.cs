using MediatR;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Commands.Auth;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(
        IAuthService authService,
        ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Usuario usuario = await _authService.ValidarCredenciaisAsync(request.Login, request.Senha);

        var token = await _tokenService.GerarTokenAsync(usuario.Id, usuario.Login);

        return token;
    }
}