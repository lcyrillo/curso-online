using AutoMapper;
using CursoOnline.Application.Request;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Application.Mapping;

public class RequestModelToModel : Profile
{
    public RequestModelToModel()
    {
        CreateMap<TipoUsuarioRequest, TipoUsuario>().ReverseMap();
        CreateMap<CursoRequest, Curso>().ReverseMap();
        CreateMap<UsuarioRequest, Usuario>().ReverseMap();
    }
}
