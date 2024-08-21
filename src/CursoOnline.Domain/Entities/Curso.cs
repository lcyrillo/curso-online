using CursoOnline.Domain.Enums;

namespace CursoOnline.Domain.Entities
{
    public class Curso
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Sobre { get; private set; } = string.Empty;
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal? Valor { get; private set; }
        public Professor? Professor { get; set; }
        public int? IdProfessor { get; set; }
        public List<Aluno>? Alunos { get; set; }
        public List<CursoAluno>? CursoAlunos { get; set; }
    }
}
