using MediatR;
using Veiculos.Application.DTOs;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Queries.Veiculos;

public class ListarVeiculosQueryHandler : IRequestHandler<ListarVeiculosQuery, IEnumerable<VeiculoResponseDto>>
{
    private readonly IVeiculoService _service;


    public ListarVeiculosQueryHandler(IVeiculoService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<VeiculoResponseDto>> Handle(ListarVeiculosQuery request, CancellationToken cancellationToken)
    {
        var veiculos = await _service.ListarAsync();

        return veiculos.Select(u => new VeiculoResponseDto
        {
            Id = u.Id,
            Descricao = u.Descricao,
            Marca =  (int)u.Marca,
            MarcaNome = u.Marca.ToString(),
            Modelo = u.Modelo,
            Valor = u.Valor
        });
    }
}
