using Veiculos.Domain.Entities;

namespace Veiculos.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task AdicionarAsync(Veiculo veiculo);
        Task AtualizarAsync(Veiculo veiculo);
        Task RemoverAsync(Veiculo veiculo);
        Task<Veiculo?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Veiculo>> ListarAsync();
    }
}
