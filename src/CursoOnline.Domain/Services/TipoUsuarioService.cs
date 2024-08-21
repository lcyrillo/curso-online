using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Domain.Interfaces.Services;

namespace CursoOnline.Domain.Services;

public class TipoUsuarioService : BaseService<TipoUsuario>, ITipoUsuarioService
{
    public TipoUsuarioService(IBaseRepository<TipoUsuario> repository) 
        : base(repository)
    {
    }
}
