using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Interfaces.Services;

public interface IUsuarioService : IBaseService<Usuario>
{
    Task<Usuario> AlterarSenha(Usuario usuario, string password);
    Task<Usuario> GerarSenha(Usuario usuario);
    Task<Usuario> GravarSenha(Usuario usuario, string senha);
    Task<Usuario?> GetByMail(string email);
    bool VerificarSenha(string password, byte[]? passwordHash, byte[]? passwordSalt);
    Task<Usuario?> GetBySenhaProv(Usuario usuario, string senhaProv);
}
