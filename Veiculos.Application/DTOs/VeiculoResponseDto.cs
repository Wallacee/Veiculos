namespace Veiculos.Application.DTOs;

public class VeiculoResponseDto
{
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Marca { get; set; }
    public string MarcaNome { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public decimal? Valor { get; set; }
}