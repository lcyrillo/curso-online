using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> AlterarSenha(Usuario usuario);
    Task<Usuario> GravarSenha(Usuario usuario);
    Task<Usuario?> GetByMail(string email);
    Task<Usuario?> GetBySenhaProv(Usuario usuario, string senhaProv);
}
