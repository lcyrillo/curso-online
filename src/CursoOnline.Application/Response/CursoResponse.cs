using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Enums;

namespace CursoOnline.Application.Response;

public class CursoResponse
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Sobre { get; private set; } = string.Empty;
    public int CargaHoraria { get; private set; }
    public PublicoAlvo PublicoAlvo { get; private set; }
    public decimal? Valor { get; private set; }
    public Professor? Professor { get; set; }
}
