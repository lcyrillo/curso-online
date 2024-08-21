using CursoOnline.Application.Request;
using CursoOnline.Application.Response;

namespace CursoOnline.Application.Interfaces;

public interface IUsuarioApplication
{
    Task<UsuarioResponse> Add(UsuarioRequest usuarioRequest);
    Task<UsuarioResponse?> Delete(int id);
    Task<IEnumerable<UsuarioResponse>> GetAll();
    Task<UsuarioResponse> GetById(int id);
    Task<UsuarioLoginResponse?> GetByMail(string email);
    Task<UsuarioResponse> Update(UsuarioRequest usuarioRequest);
    Task<UsuarioResponse> AlterarSenha(UsuarioRequest usuarioRequest, string password);
    Task<UsuarioResponse> GerarSenha(UsuarioRequest usuarioRequest);
    Task<UsuarioResponse> GravarSenha(UsuarioRequest usuarioRequest, string password);
    Task<UsuarioResponse> GetBySenhaProv(UsuarioRequest usuarioRequest, string senhaProv);
    bool VerificarSenha(string password, byte[]? passwordHash, byte[]? passwordSalt);
}