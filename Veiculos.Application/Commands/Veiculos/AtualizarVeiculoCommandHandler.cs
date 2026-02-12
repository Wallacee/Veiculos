using MediatR;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Veiculos;

public class AtualizarVeiculoCommandHandler : IRequestHandler<AtualizarVeiculoCommand, Unit>
{
    private readonly IVeiculoService _service;

    public AtualizarVeiculoCommandHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<Unit> Handle(AtualizarVeiculoCommand request, CancellationToken cancellationToken)
    {
        await _service.AtualizarAsync(
            request.Id,
            request.Descricao,
            request.Marca,
            request.Modelo,
            request.Valor);

        return Unit.Value;
    }
}
