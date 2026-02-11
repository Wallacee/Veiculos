using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Veiculos;

public class ExcluirVeiculoCommandHandler : IRequestHandler<ExcluirVeiculoCommand, Unit>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public ExcluirVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<Unit> Handle(ExcluirVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.ObterPorIdAsync(request.Id);

        if (veiculo is null)
            throw new KeyNotFoundException("Veículo não encontrado");

        await _veiculoRepository.RemoverAsync(veiculo);

        return Unit.Value;
    }
}