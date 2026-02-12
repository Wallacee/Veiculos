using MediatR;
using Veiculos.Application.DTOs;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Queries.Usuarios;

public record ObterUsuarioPorIdQuery(Guid Id) : IRequest<UsuarioResponseDto?>;

