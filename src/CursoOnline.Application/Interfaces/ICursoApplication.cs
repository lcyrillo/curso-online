using CursoOnline.Application.Request;
using CursoOnline.Application.Response;

namespace CursoOnline.Application.Interfaces;

public interface ICursoApplication
{
    Task<CursoResponse> Add(CursoRequest entity);
    Task<CursoResponse?> Delete(int id);
    Task<IEnumerable<CursoResponse>> GetAll();
    Task<CursoResponse> GetById(int id);
    Task<IEnumerable<CursoResponse>> GetByName(string name);
    Task<CursoResponse> Update(CursoRequest entity);
}
