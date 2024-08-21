using AutoMapper;
using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Request;
using CursoOnline.Application.Response;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Services;

namespace CursoOnline.Application.Application;

public class TipoUsuarioApplication : ITipoUsuarioApplication
{
    private readonly IMapper _mapper;
    private readonly ITipoUsuarioService _tipoUsuarioService;

    public TipoUsuarioApplication(IMapper mapper, ITipoUsuarioService tipoUsuarioService)      
    {
        _mapper = mapper;
        _tipoUsuarioService = tipoUsuarioService;
    }

    public async Task<TipoUsuarioResponse> Add(TipoUsuarioRequest tipoUsuarioRequest)
    {
        var tipoUsuario = _mapper.Map<TipoUsuario>(tipoUsuarioRequest);
        var result = await _tipoUsuarioService.Add(tipoUsuario);

        return _mapper.Map<TipoUsuarioResponse>(result);
    }

    public async Task<TipoUsuarioResponse?> Delete(int id)
    {
        var tipoUsuarioResult = _tipoUsuarioService.GetById(id).Result;

        if (tipoUsuarioResult != null)
        {
            await _tipoUsuarioService.Delete(tipoUsuarioResult);
            return _mapper.Map<TipoUsuarioResponse>(tipoUsuarioResult);
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<TipoUsuarioResponse>> GetAll()
    {
        var result = await _tipoUsuarioService.GetAll();

        return _mapper.Map<IEnumerable<TipoUsuarioResponse>>(result);
    }

    public async Task<TipoUsuarioResponse> GetById(int id)
    {
        var result = await _tipoUsuarioService.GetById(id);

        return _mapper.Map<TipoUsuarioResponse>(result);
    }

    public async Task<TipoUsuarioResponse> Update(TipoUsuarioRequest tipoUsuarioRequest)
    {
        var tipoUsuario = _mapper.Map<TipoUsuario>(tipoUsuarioRequest);
        var result = await _tipoUsuarioService.Update(tipoUsuario);

        return _mapper.Map<TipoUsuarioResponse>(result);
    }
}
