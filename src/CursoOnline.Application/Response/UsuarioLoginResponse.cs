
namespace CursoOnline.Application.Response;

public class UsuarioLoginResponse
{
    public string Email { get; set; } = string.Empty;
    public byte[]? SenhaHash { get; set; }
    public byte[]? SenhaSalt { get; set; }
    public string Role { get; set; } = string.Empty;
}
