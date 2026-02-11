using MediatR;
using Veiculos.Application.Services;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Auth;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAuthService _authService;

    public LoginCommandHandler(
        IUsuarioRepository usuarioRepository,
        IAuthService authService)
    {
        _usuarioRepository = usuarioRepository;
        _authService = authService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        var usuario = await _usuarioRepository.ObterPorLoginAsync(request.Login) ?? throw new UnauthorizedAccessException("Login ou senha inválidos");
        
        var senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash);

        if (!senhaValida)
            throw new UnauthorizedAccessException("Login ou senha inválidos");

        var token = await _authService.GerarTokenAsync(usuario.Id, usuario.Login);

        return token;
    }
}