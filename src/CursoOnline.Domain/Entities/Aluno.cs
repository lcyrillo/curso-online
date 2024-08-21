
namespace CursoOnline.Domain.Entities;

public class Aluno : Usuario
{
    public int IdUsuario { get; set; }

    public int RA { get; private set; }

    public List<Curso>? Cursos { get; set; }

    public List<CursoAluno>? CursoAlunos { get; set; }
}
