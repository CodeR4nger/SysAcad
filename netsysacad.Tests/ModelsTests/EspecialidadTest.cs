using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class EspecialidadTests
{
    [Fact]
    public void EspecialidadTest()
    {
        var especialidad = TestDataFactory.CreateEspecialidad();

        Assert.NotNull(especialidad);
        Assert.Equal("Ingeniería de Software", especialidad.Nombre);
        Assert.Equal("S", especialidad.Letra);
        Assert.Equal("Orientada al desarrollo de sistemas", especialidad.Observacion);
        Assert.NotNull(especialidad.TipoEspecialidad);
        Assert.Equal("Técnica", especialidad.TipoEspecialidad.Nombre);
        Assert.Equal("Intermedio", especialidad.TipoEspecialidad.Nivel);
    }
}

