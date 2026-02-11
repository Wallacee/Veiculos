using MediatR;

namespace Veiculos.Application.Commands.Veiculos;

public record ExcluirVeiculoCommand(Guid Id) : IRequest<Unit>;
