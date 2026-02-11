using MediatR;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Queries.Veiculos;

public record ObterVeiculoPorIdQuery(Guid Id) : IRequest<Veiculo?>;
