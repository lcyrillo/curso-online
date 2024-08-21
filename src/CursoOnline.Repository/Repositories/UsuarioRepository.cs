using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Repository.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    private readonly CursoOnlineContext _context;

    public UsuarioRepository(CursoOnlineContext context) 
        : base(context)
    {
        _context = context;
    }

    public async Task<Usuario> AlterarSenha(Usuario usuario)
    {
        try
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return usuario;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<Usuario?> GetByMail(string email)
    {
        return await _context.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();
    }

    public async Task<Usuario?> GetBySenhaProv(Usuario usuario, string senhaProv)
    {
        return await _context.Usuarios.Where(x => x.SenhaProvisoria == senhaProv && x.Id == usuario.Id && x.Email == usuario.Email).FirstAsync();
    }

    public async Task<Usuario> GravarSenha(Usuario usuario)
    {
        try
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return usuario;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}
