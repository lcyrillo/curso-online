namespace CursoOnline.Application.Request;

public class TipoUsuarioRequest
{
    public int Id { get; private set; }
    public string Descricao { get; set; } = string.Empty;
}
