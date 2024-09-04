using CursoOnline.Application.Request;
using CursoOnline.Application.Response;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Application.Interfaces;

public interface ICursoApplication
{
    Task<CursoResponse> Add(CursoRequest entity);
    Task<CursoResponse?> Delete(int id);
    Task<IEnumerable<CursoResponse>> GetAll();
    Task<CursoResponse> GetById(int id);
    Task<IEnumerable<CursoResponse>> GetByName(string name);
    Task<CursoResponse> Update(CursoRequest entity);
    Task<CursoResponse?> Approve(int id);
    Task<CursoResponse?> EnrollProfessor(int idProfessor, int idCurso);
}
