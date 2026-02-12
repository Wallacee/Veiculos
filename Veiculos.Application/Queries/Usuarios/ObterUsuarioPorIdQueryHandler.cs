using MediatR;
using Veiculos.Application.DTOs;
using Veiculos.Application.Interfaces;

namespace Veiculos.Application.Queries.Usuarios;

public class ObterUsuarioPorIdQueryHandler : IRequestHandler<ObterUsuarioPorIdQuery, UsuarioResponseDto?>
{
    private readonly IUsuarioService _usuarioService;

    public ObterUsuarioPorIdQueryHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public async Task<UsuarioResponseDto?> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioService.ObterPorIdAsync(request.Id);
        
        if (usuario is null)
            return null;

        return new UsuarioResponseDto()
        {
            Id = usuario.Result.Id,
            Login = usuario.Result.Login,
            Nome = usuario.Result.Nome
        };
    }
}
