
namespace CursoOnline.Domain.Entities;

public class TipoUsuario
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public List<Usuario>? Usuarios { get; set; }
}
