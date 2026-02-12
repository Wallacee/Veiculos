using MediatR;
using Veiculos.Application.DTOs;

namespace Veiculos.Application.Queries.Veiculos;

public record ListarVeiculosQuery() : IRequest<IEnumerable<VeiculoResponseDto>>;

