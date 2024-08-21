using AutoMapper;
using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Request;
using CursoOnline.Application.Response;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Services;

namespace CursoOnline.Application.Application;

public class UsuarioApplication : IUsuarioApplication
{
    private readonly IMapper _mapper;
    private readonly IUsuarioService _usuarioService;

    public UsuarioApplication(IMapper mapper, IUsuarioService usuarioService)
    {
        _mapper = mapper;
        _usuarioService = usuarioService;
    }

    public async Task<UsuarioResponse> Add(UsuarioRequest usuarioRequest)
    {
        var usuario = _mapper.Map<Usuario>(usuarioRequest);
        var result = await _usuarioService.Add(usuario);

        return _mapper.Map<UsuarioResponse>(result);
    }

    public async Task<UsuarioResponse?> AlterarSenha(UsuarioRequest usuarioRequest, string password)
    {
        var result = await _usuarioService.GetById(usuarioRequest.Id);

        if (result != null)
        {
            var usuario = _mapper.Map<Usuario>(usuarioRequest);
            var usuarioSenhaAlterada = await _usuarioService.AlterarSenha(usuario, password);
            return _mapper.Map<UsuarioResponse>(usuarioSenhaAlterada);
        }
        else
        {
            return null;
        }
    }

    public async Task<UsuarioResponse?> Delete(int id)
    {
        var usuarioResult = _usuarioService.GetById(id).Result;

        if (usuarioResult != null)
        {
            await _usuarioService.Delete(usuarioResult);
            return _mapper.Map<UsuarioResponse?>(usuarioResult);
        }
        else
        {
            return null;
        }
    }

    public async Task<UsuarioResponse> GerarSenha(UsuarioRequest usuarioRequest)
    {
        var usuarioResult = await _usuarioService.GetById(usuarioRequest.Id);

        if (usuarioResult != null)
        {
            var usuario = _mapper.Map<Usuario>(usuarioResult);
            var result = await _usuarioService.GerarSenha(usuario);
            return _mapper.Map<UsuarioResponse>(result);
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<UsuarioResponse>> GetAll()
    {
        var result = await _usuarioService.GetAll();
        return _mapper.Map<IEnumerable<UsuarioResponse>>(result);
    }

    public async Task<UsuarioLoginResponse?> GetByMail(string email)
    {
        var result = await _usuarioService.GetByMail(email);
        return _mapper.Map<UsuarioLoginResponse>(result);
    }

    public async Task<UsuarioResponse> GetById(int id)
    {
        var result = await _usuarioService.GetById(id);
        return _mapper.Map<UsuarioResponse>(result);
    }

    public async Task<UsuarioResponse> GravarSenha(UsuarioRequest usuario, string password)
    {
        var usuarioResult = await _usuarioService.GetById(usuario.Id);

        if (usuarioResult != null)
        {
            var result = _mapper.Map<Usuario>(usuarioResult);
            var usuarioGravado = await _usuarioService.GravarSenha(result, password);
            return _mapper.Map<UsuarioResponse>(usuarioGravado);
        }
        else
        {
            return null;
        }
    }

    public async Task<UsuarioResponse> Update(UsuarioRequest usuario)
    {
        var usuarioResult = await _usuarioService.GetById(usuario.Id);

        if (usuarioResult != null)
        {
            var result = _mapper.Map<Usuario>(usuarioResult);
            var usuarioAlterado = await _usuarioService.Update(result);
            return _mapper.Map<UsuarioResponse>(usuarioAlterado);
        }
        else
        {
            return null;
        }
    }

    public bool VerificarSenha(string password, byte[]? passwordHash, byte[]? passwordSalt)
    {
        return _usuarioService.VerificarSenha(password, passwordHash, passwordSalt);
    }

    public async Task<UsuarioResponse> GetBySenhaProv(UsuarioRequest usuarioRequest, string senhaProv)
    {
        var usuarioResult = await _usuarioService.GetById(usuarioRequest.Id);

        if (usuarioResult != null)
        {
            var result = _mapper.Map<Usuario>(usuarioResult);
            var usuario = await _usuarioService.GetBySenhaProv(result, senhaProv);
            return _mapper.Map<UsuarioResponse>(usuario);
        }
        else
        {
            return null;
        }
    }
}
