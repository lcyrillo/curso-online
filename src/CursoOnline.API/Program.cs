using CursoOnline.Repository.Context;
using Microsoft.EntityFrameworkCore;
using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Application;
using CursoOnline.Domain.Interfaces.Services;
using CursoOnline.Domain.Services;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Repositories;
using CursoOnline.Repository.Repositories;
using CursoOnline.Application.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using CursoOnline.API;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CursoOnlineContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging();
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

// IoC

//application
builder.Services.AddScoped<ITipoUsuarioApplication, TipoUsuarioApplication>();
builder.Services.AddScoped<ICursoApplication, CursoApplication>();
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();

//services
builder.Services.AddScoped<IBaseService<TipoUsuario>, TipoUsuarioService>();
builder.Services.AddScoped<IBaseService<Curso>, CursoService>();
builder.Services.AddScoped<IBaseService<Usuario>, UsuarioService>();

builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//repositories
builder.Services.AddScoped<IBaseRepository<TipoUsuario>, TipoUsuarioRepository>();
builder.Services.AddScoped<IBaseRepository<Curso>, CursoRepository>();
builder.Services.AddScoped<IBaseRepository<Usuario>, UsuarioRepository>();

builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddAutoMapper(typeof(ModelToResponseModel));
builder.Services.AddAutoMapper(typeof(RequestModelToModel));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
