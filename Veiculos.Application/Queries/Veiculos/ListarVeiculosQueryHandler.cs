using MediatR;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Queries.Veiculos;

public class ListarVeiculosQueryHandler : IRequestHandler<ListarVeiculosQuery, IEnumerable<Veiculo>>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public ListarVeiculosQueryHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<IEnumerable<Veiculo>> Handle(ListarVeiculosQuery request, CancellationToken cancellationToken)
    {
        return await _veiculoRepository.ListarAsync();
    }
}
