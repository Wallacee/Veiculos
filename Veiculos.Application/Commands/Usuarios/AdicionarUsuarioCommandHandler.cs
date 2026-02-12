using MediatR;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Commands.Usuarios;

public class AdicionarUsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, Usuario>
{
    private readonly IUsuarioService _usuarioService;

    public AdicionarUsuarioCommandHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public async Task<Usuario> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var existe = await _usuarioService.ObterPorLoginAsync(request.Login);
        
        if (existe is not null)
            throw new InvalidOperationException("Login já cadastrado");
        
        var hash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

        return await _usuarioService.AdicionarAsync(request.Nome, request.Login,hash);   
    }
}

