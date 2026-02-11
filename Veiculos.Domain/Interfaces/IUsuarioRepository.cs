using Veiculos.Domain.Entities;

namespace Veiculos.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarAsync(Usuario usuario);
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task<Usuario?> ObterPorLoginAsync(string login);
        Task<bool> ExisteLoginAsync(string login);
    }
}
