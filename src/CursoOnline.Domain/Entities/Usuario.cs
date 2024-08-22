
namespace CursoOnline.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public byte[]? SenhaHash { get; set; }
    public byte[]? SenhaSalt { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public int IdTipoUsuario { get; set; }
    public string? SenhaProvisoria { get; set; } = string.Empty;
    public TipoUsuario? TipoUsuario { get; set; }
}
