
namespace CursoOnline.Domain.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
}