using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class AutoridadTests
{
    [Fact]
    public void AutoridadTest()
     {
        var autoridad =  TestDataFactory.CreateAutoridad();
        Assert.NotNull(autoridad);
        Assert.Equal("PruebaAutoridad",autoridad.Nombre);
        Assert.Equal("rrhh",autoridad.Cargo);
        Assert.Equal("1234553",autoridad.Telefono);
        Assert.Equal("hguthg@gmail.com",autoridad.Email);
    }
}