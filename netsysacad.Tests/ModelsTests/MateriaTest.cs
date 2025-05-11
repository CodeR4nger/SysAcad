using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class MateriaTests
{
    [Fact]
    public void MateriaTest()
     {
        var materia = TestDataFactory.CreateMateria();

        Assert.NotNull(materia);
        Assert.Equal("Desarrollo de software",materia.Nombre);
        Assert.Equal("102",materia.Codigo);
        Assert.Equal("Ninguna observacion",materia.Observacion);
    }
}