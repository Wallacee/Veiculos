namespace Veiculos.Application.Interfaces;

public interface ITokenService
{
    Task<string> GerarTokenAsync(Guid usuarioId, string login);
}