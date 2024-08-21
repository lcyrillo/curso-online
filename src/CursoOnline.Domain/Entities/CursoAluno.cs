namespace CursoOnline.Domain.Entities;

public class CursoAluno
{
    public int Id { get; private set; }
    public int IdCurso { get; set; }
    public int IdAluno { get; set; }
    public Curso? Curso { get; set; }
    public Aluno? Aluno { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int ProgressoCurso { get; set; }
}
