using MediatR;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Queries.Usuarios;

public class ObterUsuarioPorIdQueryHandler : IRequestHandler<ObterUsuarioPorIdQuery, Usuario?>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuarioPorIdQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario?> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _usuarioRepository.ObterPorIdAsync(request.Id);
    }
}
