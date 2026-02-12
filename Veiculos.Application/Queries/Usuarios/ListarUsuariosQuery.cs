using MediatR;
using Veiculos.Application.DTOs;

namespace Veiculos.Application.Queries.Usuarios;

public record ListarUsuariosQuery() : IRequest<IEnumerable<UsuarioResponseDto>>;


