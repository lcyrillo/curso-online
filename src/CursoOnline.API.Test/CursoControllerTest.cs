using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Enums;
using CursoOnline.Domain.Interfaces.Services;
using Moq;

namespace CursoOnline.API.Test;

public class CursoControllerTest
{
    [Fact]
    public async void ListaCursoNaoVazia()
    {
        //Arrange
        var cursoServiceMock = new Mock<ICursoService>();
        cursoServiceMock.Setup(service => service.GetAll())
            .ReturnsAsync(new List<Curso>()
            {
                new Curso()
                {
                    Nome = "Teste",
                    Sobre = "Teste",
                    CargaHoraria = 120,
                    PublicoAlvo = PublicoAlvo.Estudante,
                    Valor = 100,
                    Professor = null,
                    IdProfessor = null,
                    Aprovado = false,
                    Alunos = new List<Aluno>(),
                    CursoAlunos = new List<CursoAluno>()
                }
            });

        //Act
        var result = await cursoServiceMock.Object.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
