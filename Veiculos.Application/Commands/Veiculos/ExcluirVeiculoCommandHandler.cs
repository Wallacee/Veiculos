using MediatR;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Veiculos;

public class ExcluirVeiculoCommandHandler : IRequestHandler<ExcluirVeiculoCommand, Unit>
{
    private readonly IVeiculoService _service;

    public ExcluirVeiculoCommandHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<Unit> Handle(ExcluirVeiculoCommand request, CancellationToken cancellationToken)
    {
        await _service.RemoverAsync(request.Id);
        return Unit.Value;
    }
}