using netsysacad.Models;
namespace netsysacad.Tests.ModelsTests;

public class GradoTests
{
    private static Grado CreateGrado()
    {
        return new Grado
        {
            Nombre = "Licenciatura", 
        };
    }
    [Fact]
    public void GradoTest()
     {
        var grado = CreateGrado();
        Assert.NotNull(grado);
        Assert.Equal("Licenciatura",grado.Nombre);
    }
}