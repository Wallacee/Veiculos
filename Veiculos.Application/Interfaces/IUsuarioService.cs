using Veiculos.Domain.Entities;

namespace Veiculos.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> AdicionarAsync(string nome, string login, string senha);

        Task<Usuario?> ObterPorIdAsync(Guid id);

        Task<Usuario?> ObterPorLoginAsync(string login);

        Task<IEnumerable<Usuario>> ListarAsync();
    }
}
