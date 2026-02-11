using MediatR;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Queries.Veiculos;

public class ObterVeiculoPorIdQueryHandler : IRequestHandler<ObterVeiculoPorIdQuery, Veiculo?>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public ObterVeiculoPorIdQueryHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<Veiculo?> Handle(ObterVeiculoPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _veiculoRepository.ObterPorIdAsync(request.Id);
    }
}
