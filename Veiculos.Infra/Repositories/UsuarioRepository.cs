using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;
using Veiculos.Infra.Context;

namespace Veiculos.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario?> ObterPorIdAsync(Guid id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
    }

    public async Task<Usuario?> ObterPorLoginAsync(string login)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(usiario => usiario.Login == login);
    }

    public async Task<bool> ExisteLoginAsync(string login)
    {
        return await _context.Usuarios.AnyAsync(usuario => usuario.Login == login);
    }
}

