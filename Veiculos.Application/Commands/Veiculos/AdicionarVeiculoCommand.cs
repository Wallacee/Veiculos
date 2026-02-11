using MediatR;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Enum;

namespace Veiculos.Application.Commands.Veiculos;

public record AdicionarVeiculoCommand(
    string Descricao,
    Marca Marca,
    string Modelo,
    decimal? Valor
) : IRequest<Veiculo>;
