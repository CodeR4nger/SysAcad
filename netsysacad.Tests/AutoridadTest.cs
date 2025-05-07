using netsysacad.Models;
namespace netsysacad.Tests;

public class AutoridadTests
{
    [Fact]
    public void AutoridadTest()
     {
        var autoridad = new Autoridad
        {
            Nombre = "PruebaAutoridad", 
            Cargo = "rrhh",
            Telefono = "1234553",
            Email = "hguthg@gmail.com"
        };

        Assert.NotNull(autoridad);
        Assert.Equal("PruebaAutoridad",autoridad.Nombre);
        Assert.Equal("rrhh",autoridad.Cargo);
        Assert.Equal("1234553",autoridad.Telefono);
        Assert.Equal("hguthg@gmail.com",autoridad.Email);
    }
}