using MediatR;
using Veiculos.Application.DTOs;

namespace Veiculos.Application.Queries.Veiculos;

public record ObterVeiculoPorIdQuery(Guid Id) : IRequest<VeiculoResponseDto?>;
