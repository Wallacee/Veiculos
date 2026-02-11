using MediatR;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Usuarios;

public class AdicionarUsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, Usuario>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AdicionarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
    {
        
        var existe = await _usuarioRepository.ExisteLoginAsync(request.Login);
        
        if (existe)
            throw new InvalidOperationException("Login já cadastrado");

        
        var hash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

        
        var usuario = new Usuario(request.Nome, request.Login, hash);

        
        await _usuarioRepository.AdicionarAsync(usuario);

        return usuario;
    }
}

