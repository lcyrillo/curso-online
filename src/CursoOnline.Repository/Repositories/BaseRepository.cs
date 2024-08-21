using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly CursoOnlineContext _context;

    public BaseRepository(CursoOnlineContext context)
    {
        _context = context;
    }

    public async Task<T> Add(T entity)
    {
        try
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<T> Delete(T entity)
    {
        try 
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> Update(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public void Dispose()
    {
        this.Dispose();
    }

}