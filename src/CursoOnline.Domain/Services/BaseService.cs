using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Domain.Interfaces.Services;

namespace CursoOnline.Domain.Services;

public class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IBaseRepository<T> _repository;

    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> Add(T entity)
    {
       return await _repository.Add(entity);
    }

    public async Task<T> Delete(T entity)
    {
        return await _repository.Delete(entity);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<T> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<T> Update(T entity)
    {
        return await _repository.Update(entity);
    }

    public void Dispose()
    {
        this.Dispose();
    }
}
