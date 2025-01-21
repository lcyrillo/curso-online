using CursoOnline.Domain.Enums;

namespace CursoOnline.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobre { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public decimal? Valor { get; set; }
        public Professor? Professor { get; set; }
        public int? IdProfessor { get; set; }
        public bool? Aprovado { get; set; } = false;
        public List<Aluno>? Alunos { get; set; }
        public List<CursoAluno>? CursoAlunos { get; set; }
    }
}
