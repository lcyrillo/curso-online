
namespace CursoOnline.Domain.Entities;

public class Professor : Usuario
{
    public int IdUsuario { get; set; }
    public List<Curso>? Cursos { get; set; }
}
