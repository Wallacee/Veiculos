using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Usuario> AdicionarAsync(string nome, string login, string senha)
    {
        if (await _repository.ExisteLoginAsync(login))
            throw new InvalidOperationException("Login já cadastrado");

        var hash = BCrypt.Net.BCrypt.HashPassword(senha);

        var usuario = new Usuario(nome, login, hash);

        await _repository.AdicionarAsync(usuario);

        return usuario;
    }
    public Task<IEnumerable<Usuario>> ListarAsync()
      => _repository.ListarAsync();

    public Task<Usuario?> ObterPorIdAsync(Guid id)
        => _repository.ObterPorIdAsync(id);

    public Task<Usuario?> ObterPorLoginAsync(string login)
        => _repository.ObterPorLoginAsync(login);
}