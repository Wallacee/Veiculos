using Veiculos.Domain.Entities;
using Veiculos.Domain.Enum;

namespace Veiculos.Application.Services
{
    public interface IVeiculoService
    {
        Task<Veiculo> AdicionarAsync(string descricao, Marca marca, string modelo, decimal? valor);

        Task AtualizarAsync(Guid id, string descricao, Marca marca, string modelo, decimal? valor);

        Task RemoverAsync(Guid id);

        Task<Veiculo?> ObterPorIdAsync(Guid id);

        Task<IEnumerable<Veiculo>> ListarAsync();
    }
}
