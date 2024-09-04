using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Repository.Context;

namespace CursoOnline.Repository.Repositories;

public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
{
    public readonly CursoOnlineContext _context;

    public ProfessorRepository(CursoOnlineContext context) 
        : base(context)
    {
        _context = context;
    }
}
