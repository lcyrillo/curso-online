using AutoMapper;
using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Request;
using CursoOnline.Application.Response;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Services;

namespace CursoOnline.Application.Application;

public class CursoApplication : ICursoApplication
{
    private readonly IMapper _mapper;
    private readonly ICursoService _cursoService;

    public CursoApplication(IMapper mapper, ICursoService cursoService)
    {
        _mapper = mapper;
        _cursoService = cursoService;
    }

    public async Task<CursoResponse> Add(CursoRequest cursoRequest)
    {
        var curso = _mapper.Map<Curso>(cursoRequest);
        var result = await _cursoService.Add(curso);

        return _mapper.Map<CursoResponse>(result);
    }

    public async Task<CursoResponse?> Approve(CursoRequest entity)
    {
        var cursoResult = await _cursoService.GetById(entity.Id);

        if (cursoResult != null)
        {
            await _cursoService.Approve(cursoResult);
            return _mapper.Map<CursoResponse?>(cursoResult);
        }
        else
        {
            return null;
        }
    }

    public async Task<CursoResponse?> Delete(int id)
    {
        var cursoResult = _cursoService.GetById(id).Result;

        if (cursoResult != null)
        {
            await _cursoService.Delete(cursoResult);
            return _mapper.Map<CursoResponse?>(cursoResult);
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<CursoResponse>> GetAll()
    {
        var result = await _cursoService.GetAll();

        return _mapper.Map<IEnumerable<CursoResponse>>(result);
    }

    public async Task<CursoResponse> GetById(int id)
    {
        var result = await _cursoService.GetById(id);

        return _mapper.Map<CursoResponse>(result);
    }

    public async Task<IEnumerable<CursoResponse>> GetByName(string name)
    {
        var result = await _cursoService.GetByName(name);

        return _mapper.Map<IEnumerable<CursoResponse>>(result);
    }

    public async Task<CursoResponse> Update(CursoRequest cursoRequest)
    {
        var curso = _mapper.Map<Curso>(cursoRequest);
        var result = await _cursoService.Update(curso);

        return _mapper.Map<CursoResponse>(result);
    }
}
