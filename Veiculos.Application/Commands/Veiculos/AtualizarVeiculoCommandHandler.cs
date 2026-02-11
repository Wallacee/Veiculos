using MediatR;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Veiculos;

public class AtualizarVeiculoCommandHandler : IRequestHandler<AtualizarVeiculoCommand, Unit>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public AtualizarVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<Unit> Handle(AtualizarVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.ObterPorIdAsync(request.Id);

        if (veiculo is null)
            throw new KeyNotFoundException("Veículo não encontrado");

        veiculo.Atualizar(request.Descricao, request.Marca, request.Modelo, request.Valor);

        await _veiculoRepository.AtualizarAsync(veiculo);

        return Unit.Value;
    }
}
