using Veiculos.Application.Interfaces;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Enum;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Services;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _repository;

    public VeiculoService(IVeiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Veiculo> AdicionarAsync(string descricao, Marca marca, string modelo, decimal? valor)
    {
        var veiculo = new Veiculo(descricao, marca, modelo, valor);

        await _repository.AdicionarAsync(veiculo);
        
        return veiculo;
    }

    public async Task AtualizarAsync(Guid id, string descricao, Marca marca, string modelo, decimal? valor)
    {
        var veiculo = await _repository.ObterPorIdAsync(id) ?? throw new KeyNotFoundException("Veículo não encontrado");

        veiculo.Atualizar(descricao, marca, modelo, valor);

        await _repository.AtualizarAsync(veiculo);
    }

    public async Task RemoverAsync(Guid id)
    {
        var veiculo = await _repository.ObterPorIdAsync(id) ?? throw new KeyNotFoundException("Veículo não encontrado");

        await _repository.RemoverAsync(veiculo);
    }

    public Task<Veiculo?> ObterPorIdAsync(Guid id) => _repository.ObterPorIdAsync(id);

    public Task<IEnumerable<Veiculo>> ListarAsync() => _repository.ListarAsync();
}