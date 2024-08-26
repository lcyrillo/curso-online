using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Domain.Interfaces.Services;

namespace CursoOnline.Domain.Services;

public class CursoService : BaseService<Curso>, ICursoService
{
    private readonly ICursoRepository _cursoRepository;

    public CursoService(IBaseRepository<Curso> repository, ICursoRepository cursoRepository)
        : base(repository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<Curso> Approve(Curso curso)
    {
        curso.Aprovado = true;

        return await _cursoRepository.Update(curso);
    }

    public async Task<IEnumerable<Curso>> GetByName(string name)
    {
        return await _cursoRepository.GetByName(name);
    }


}
