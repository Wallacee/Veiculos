using MediatR;
using Veiculos.Domain.Enum;

namespace Veiculos.Application.Commands.Veiculos;

public record AtualizarVeiculoCommand(
    Guid Id,
    string Descricao,
    Marca Marca,
    string Modelo,
    decimal? Valor
) : IRequest<Unit>;
