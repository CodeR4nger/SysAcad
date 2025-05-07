using netsysacad.Models;
namespace netsysacad.Tests;

public class GradoTests
{
    [Fact]
    public void GradoTest()
     {
        var grado = new Grado
        {
            Nombre = "PruebaGrado", 
        };

        Assert.NotNull(grado);
        Assert.Equal("PruebaGrado",grado.Nombre);
    }
}