using CursoOnline.Domain.Enums;

namespace CursoOnline.Application.Request;

public class CursoRequest
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobre { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public PublicoAlvo PublicoAlvo { get; set; }
    public decimal? Valor { get; set; }
    public int? IdProfessor { get; set; }
}
