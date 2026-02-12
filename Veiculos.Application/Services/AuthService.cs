using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _repository;

    public AuthService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Usuario> ValidarCredenciaisAsync(string login, string senha)
    {
        var usuario = await _repository.ObterPorLoginAsync(login);

        if (usuario is null)
            throw new UnauthorizedAccessException("Login ou senha inválidos");

        var senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);

        if (!senhaValida)
            throw new UnauthorizedAccessException("Login ou senha inválidos");

        return usuario;
    }
}