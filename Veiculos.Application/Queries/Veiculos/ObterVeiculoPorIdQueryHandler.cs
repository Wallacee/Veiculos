using MediatR;
using Veiculos.Application.DTOs;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Queries.Veiculos;

public class ObterVeiculoPorIdQueryHandler : IRequestHandler<ObterVeiculoPorIdQuery, VeiculoResponseDto?>
{
    private readonly IVeiculoService _service;


    public ObterVeiculoPorIdQueryHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<VeiculoResponseDto?> Handle(ObterVeiculoPorIdQuery request, CancellationToken cancellationToken)
    {
        var veiculo = await _service.ObterPorIdAsync(request.Id);

        if (veiculo is null)
            return null;

        return new VeiculoResponseDto()
        {
            Id = veiculo.Id,
            Descricao = veiculo.Descricao,
            Marca = (int)veiculo.Marca,
            MarcaNome = veiculo.Marca.ToString(),
            Modelo = veiculo.Modelo,
            Valor = veiculo.Valor
        };
    }
}
