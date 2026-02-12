using MediatR;
using Veiculos.Application.DTOs;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Queries.Usuarios;

public class ListarUsuariosQueryHandler : IRequestHandler<ListarUsuariosQuery, IEnumerable<UsuarioResponseDto>>
{
    private readonly IUsuarioService _usuarioService;

    public ListarUsuariosQueryHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public async Task<IEnumerable<UsuarioResponseDto>> Handle(
        ListarUsuariosQuery request,
        CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioService.ListarAsync();

        return usuarios.Select(u => new UsuarioResponseDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Login = u.Login
        });
    }
}