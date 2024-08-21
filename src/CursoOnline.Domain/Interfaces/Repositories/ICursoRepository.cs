using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Interfaces.Repositories;

public interface ICursoRepository : IBaseRepository<Curso>
{
    Task<IEnumerable<Curso>> GetByName(string name);
}
