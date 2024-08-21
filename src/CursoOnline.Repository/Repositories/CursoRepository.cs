using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Repository.Repositories;

public class CursoRepository : BaseRepository<Curso>, ICursoRepository
{
    private readonly CursoOnlineContext _context;

    public CursoRepository(CursoOnlineContext context)
        : base (context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Curso>> GetByName(string name)
    {
        return await _context.Cursos.Where(c => c.Nome.Contains(name)).ToListAsync();
    }
}
