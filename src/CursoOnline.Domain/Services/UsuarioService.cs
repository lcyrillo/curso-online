using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Domain.Interfaces.Services;
using CursoOnline.Infrastructure.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace CursoOnline.Domain.Services;

public class UsuarioService : BaseService<Usuario>, IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IBaseRepository<Usuario> repository, 
        IUsuarioRepository usuarioRepository)
        : base (repository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<Usuario> AlterarSenha(Usuario usuario, string password)
    {
        if (usuario.SenhaHash != null && usuario.SenhaSalt != null)
        {
            if (!VerificarSenha(password, usuario.SenhaHash, usuario.SenhaSalt))
            {
                return null;
            }
        }

        using (var hmac = new HMACSHA512())
        {
            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            usuario.SenhaHash = passwordHash;
            usuario.SenhaSalt = passwordSalt;

            _usuarioRepository.GravarSenha(usuario);
        }

        return _usuarioRepository.AlterarSenha(usuario);
    }

    public async Task<Usuario> GerarSenha(Usuario usuario)
    {
        var senhaProvisoria = SenhaHelper.GerarSenhaProvisoria();

        usuario.SenhaProvisoria = senhaProvisoria;

        return await _usuarioRepository.GravarSenha(usuario);
    }

    public async Task<Usuario?> GetByMail(string email)
    {
        return await _usuarioRepository.GetByMail(email);
    }

    public async Task<Usuario?> GetBySenhaProv(Usuario usuario, string senhaProv)
    {
        return await _usuarioRepository.GetBySenhaProv(usuario, senhaProv);
    }

    public async Task<Usuario> GravarSenha(Usuario usuario, string senha)
    {
        using (var hmac = new HMACSHA512())
        {
            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            usuario.SenhaHash = passwordHash;
            usuario.SenhaSalt = passwordSalt;
        }

        return await _usuarioRepository.GravarSenha(usuario);
    }

    public bool VerificarSenha(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}
