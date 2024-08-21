using CursoOnline.Application.Request;
using CursoOnline.Application.Response;

namespace CursoOnline.Application.Interfaces;

public interface ITipoUsuarioApplication
{
    Task<TipoUsuarioResponse> Add(TipoUsuarioRequest entity);
    Task<TipoUsuarioResponse?> Delete(int id);
    Task<IEnumerable<TipoUsuarioResponse>> GetAll();
    Task<TipoUsuarioResponse> GetById(int id);
    Task<TipoUsuarioResponse> Update(TipoUsuarioRequest entity);
}
