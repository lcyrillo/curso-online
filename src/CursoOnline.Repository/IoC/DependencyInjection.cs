using CursoOnline.Application.Application;
using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Mapping;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Domain.Interfaces.Services;
using CursoOnline.Domain.Services;
using CursoOnline.Repository.Context;
using CursoOnline.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoOnline.Repository.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CursoOnlineContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging();
        });

        services.AddAutoMapper(typeof(ModelToResponseModel));
        services.AddAutoMapper(typeof(RequestModelToModel));

        //IoC

        //application
        services.AddScoped<ITipoUsuarioApplication, TipoUsuarioApplication>();
        services.AddScoped<ICursoApplication, CursoApplication>();
        services.AddScoped<IUsuarioApplication, UsuarioApplication>();

        //services
        services.AddScoped<IBaseService<TipoUsuario>, TipoUsuarioService>();
        services.AddScoped<IBaseService<Curso>, CursoService>();
        services.AddScoped<IBaseService<Usuario>, UsuarioService>();
        services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
        services.AddScoped<ICursoService, CursoService>();
        services.AddScoped<IUsuarioService, UsuarioService>();

        //repositories
        services.AddScoped<IBaseRepository<TipoUsuario>, TipoUsuarioRepository>();
        services.AddScoped<IBaseRepository<Curso>, CursoRepository>();
        services.AddScoped<IBaseRepository<Usuario>, UsuarioRepository>();
        services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}
