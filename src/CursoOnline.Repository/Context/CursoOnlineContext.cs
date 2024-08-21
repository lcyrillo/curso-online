using CursoOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Repository.Context;

public class CursoOnlineContext : DbContext
{
    public CursoOnlineContext(DbContextOptions<CursoOnlineContext> options) 
        : base(options)
    {
        
    }

    public virtual DbSet<Curso> Cursos { get; set; }
    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Aluno> Alunos { get; set; }
    public virtual DbSet<Professor> Professors { get; set; }
    public virtual DbSet<CursoAluno> CursoAlunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id)
                  .HasName("PK_Curso");

            entity.ToTable("Curso");

            entity.Property(e => e.Nome)
                  .HasMaxLength(100);

            entity.Property(e => e.Sobre)
                  .HasMaxLength(1000);

            entity.Property(e => e.CargaHoraria)
                   .HasColumnName("CARGA_HORARIA");

            entity.Property(e => e.PublicoAlvo)
                  .HasColumnType("integer")
                  .HasColumnName("PUBLICO_ALVO");

            entity.Property(e => e.IdProfessor)
                  .HasColumnName("ID_PROFESSOR");

            entity.Property(e => e.Valor);

            entity.HasOne(e => e.Professor).WithMany(p => p.Cursos);

            entity.HasMany(e => e.Alunos).WithMany(p => p.Cursos)
                  .UsingEntity<CursoAluno>(
                       l => l.HasOne(e => e.Aluno).WithMany(e => e.CursoAlunos).HasForeignKey(e => e.IdAluno),
                       r => r.HasOne(e => e.Curso).WithMany(p => p.CursoAlunos).HasForeignKey(e => e.IdCurso));

        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id)
                  .HasName("PK_TipoUsuario");

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.Descricao)
                  .HasMaxLength(1000);

            entity.HasMany(e => e.Usuarios).WithOne(p => p.TipoUsuario)
                  .HasForeignKey(e => e.IdTipoUsuario);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id)
                  .HasName("PK_Usuario");

            entity.ToTable("Usuario");

            entity.Property(e => e.Email)
                  .HasMaxLength(1000);

            entity.Property(e => e.SenhaHash)
                  .HasColumnType("varbinary")
                  .HasMaxLength(512)
                  .HasColumnName("SENHA_HASH");

            entity.Property(e => e.SenhaSalt)
                  .HasColumnType("varbinary")
                  .HasMaxLength(512)
                  .HasColumnName("SENHA_SALT");

            entity.Property(e => e.IdTipoUsuario)
                  .HasColumnName("ID_TIPO_USUARIO");

            entity.Property(e => e.Cpf)
                  .HasMaxLength(11);

            entity.Property(e => e.SenhaProvisoria)
                  .HasColumnName("SENHA_PROV_CADASTRO");

            entity.HasOne(e => e.TipoUsuario).WithMany(p => p.Usuarios)
                  .HasForeignKey(e => e.IdTipoUsuario);
        });

        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.ToTable("Aluno");

            entity.Property(e => e.IdUsuario)
                  .HasColumnName("ID_USUARIO");

            entity.Property(e => e.RA)
                  .HasColumnType("integer");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.ToTable("Professor");

            entity.Property(e => e.IdUsuario)
                  .HasColumnName("ID_USUARIO");

            entity.HasMany(e => e.Cursos).WithOne(p => p.Professor)
                  .HasForeignKey(e => e.IdProfessor);
        });

        modelBuilder.Entity<CursoAluno>(entity =>
        {
            entity.HasKey(e => e.Id)
                  .HasName("PK_CursoAluno");

            entity.ToTable("CursoAluno");

            entity.Property(e => e.IdCurso)
                  .HasColumnName("ID_CURSO");

            entity.Property(e => e.IdAluno)
                  .HasColumnName("ID_ALUNO");

            entity.Property(e => e.DataInicio)
                  .HasColumnType("datetime")
                  .HasColumnName("DATA_INICIO");

            entity.Property(e => e.DataFim)
                  .HasColumnType("datetime")
                  .HasColumnName("DATA_FIM");

            entity.Property(e => e.ProgressoCurso)
                  .HasColumnType("integer")
                  .HasColumnName("PROGRESSO_CURSO");
        });

        base.OnModelCreating(modelBuilder);
    }
}
