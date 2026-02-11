using MediatR;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Queries.Veiculos;

public record ListarVeiculosQuery() : IRequest<IEnumerable<Veiculo>>;

