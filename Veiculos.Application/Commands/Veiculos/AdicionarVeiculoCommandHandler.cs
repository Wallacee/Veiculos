using MediatR;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Veiculos;

public class AdicionarVeiculoCommandHandler : IRequestHandler<AdicionarVeiculoCommand, Veiculo>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public AdicionarVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<Veiculo> Handle(AdicionarVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = new Veiculo(
            request.Descricao,
            request.Marca,
            request.Modelo,
            request.Valor
        );

        await _veiculoRepository.AdicionarAsync(veiculo);

        return veiculo;
    }
}
