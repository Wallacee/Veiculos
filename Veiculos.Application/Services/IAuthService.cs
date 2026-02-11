namespace Veiculos.Application.Services
{
    public interface IAuthService
    {
        Task<string> GerarTokenAsync(Guid usuarioId, string login);
    }
}
