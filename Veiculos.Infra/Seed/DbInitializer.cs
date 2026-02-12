using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Enum;
using Veiculos.Infra.Context;

namespace Veiculos.Infra.Seed;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (await context.Usuarios.AnyAsync())
            return;

        var admin = new Usuario(
            "Administrador",
            "admin",
            BCrypt.Net.BCrypt.HashPassword("123456")
        );

        await context.Usuarios.AddAsync(admin);

        var veiculos = new List<Veiculo>
        {
            new("Corolla Cross XRE", Marca.Toyota, "2023", 150000m),
            new("Civic Touring", Marca.Honda, "2022", 145000m),
            new("Onix Premier", Marca.Chevrolet, "2021", 85000m),
            new("T-Cross Highline", Marca.Volkswagen, "2023", 135000m),
            new("Ranger Limited", Marca.Ford, "2024", 220000m)
        };

        await context.Veiculos.AddRangeAsync(veiculos);
        await context.SaveChangesAsync();
    }
}