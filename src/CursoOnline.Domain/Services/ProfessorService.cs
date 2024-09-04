using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Domain.Interfaces.Services;

namespace CursoOnline.Domain.Services;

public class ProfessorService : BaseService<Professor>, IProfessorService
{
    private readonly IProfessorRepository _professorRepository;

    public ProfessorService(IBaseRepository<Professor> repository, IProfessorRepository professorRepository)
        : base(repository)
    {
        _professorRepository = professorRepository;
    }
}
