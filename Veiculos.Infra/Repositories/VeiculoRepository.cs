using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;
using Veiculos.Infra.Context;

namespace Veiculos.Infra.Repositories;

    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<Veiculo?> ObterPorIdAsync(Guid id)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Veiculo>> ListarAsync()
        {
            return await _context.Veiculos.ToListAsync();
        }
    }
