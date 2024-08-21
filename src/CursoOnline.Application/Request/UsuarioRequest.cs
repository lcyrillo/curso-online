namespace CursoOnline.Application.Request;

public class UsuarioRequest
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public int IdTipoUsuario { get; set; }
    public string Role { get; set; } = string.Empty;
}
