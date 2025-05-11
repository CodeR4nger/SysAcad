using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class TipoEspecialidadTests
{
    [Fact]
    public void TipoEspecialidadTest()
    {
        var tipoEspecialidad = TestDataFactory.CreateTipoEspecialidad();

        Assert.NotNull(tipoEspecialidad);
        Assert.Equal("Técnica", tipoEspecialidad.Nombre);
        Assert.Equal("Intermedio", tipoEspecialidad.Nivel);
    }
}

