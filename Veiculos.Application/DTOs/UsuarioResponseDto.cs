namespace Veiculos.Application.DTOs;

public class UsuarioResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
}
