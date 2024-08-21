using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Repository.Context;

namespace CursoOnline.Repository.Repositories;

public class TipoUsuarioRepository : BaseRepository<TipoUsuario>, ITipoUsuarioRepository
{
    public TipoUsuarioRepository(CursoOnlineContext context)
        : base (context)
    {
    }
}
