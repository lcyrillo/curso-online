﻿namespace CursoOnline.Application.Response;

public class UsuarioResponse
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public int IdTipoUsuario { get; set; }
    public string SenhaProvisoria { get; set; } = string.Empty;
}
