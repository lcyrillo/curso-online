using AutoMapper;
using CursoOnline.Application.Response;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Application.Mapping;

public class ModelToResponseModel : Profile
{
    public ModelToResponseModel()
    {
        CreateMap<TipoUsuario, TipoUsuarioResponse>().ReverseMap();
        CreateMap<Curso, CursoResponse>().ReverseMap();
        CreateMap<Usuario, UsuarioResponse>().ReverseMap();
    }
}
