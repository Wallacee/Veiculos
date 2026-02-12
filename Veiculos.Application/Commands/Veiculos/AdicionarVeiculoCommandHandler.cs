using MediatR;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Commands.Veiculos;

public class AdicionarVeiculoCommandHandler : IRequestHandler<AdicionarVeiculoCommand, Veiculo>
{
    private readonly IVeiculoService _service;

    public AdicionarVeiculoCommandHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<Veiculo> Handle(AdicionarVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = new Veiculo(
            request.Descricao,
            request.Marca,
            request.Modelo,
            request.Valor
        );

        return await _service.AdicionarAsync(request.Descricao, request.Marca, request.Modelo, request.Valor);

        
    }
}
