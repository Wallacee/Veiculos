using Veiculos.Domain.Entities;

namespace Veiculos.Application.Interfaces;

public interface IAuthService
{
    Task<Usuario> ValidarCredenciaisAsync(string login, string senha);
}

