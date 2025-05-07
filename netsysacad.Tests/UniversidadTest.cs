using netsysacad.Models;
namespace netsysacad.Tests;

public class UniversidadTests
{
    [Fact]
    public void UniversidadTest()
     {
        var universidad = new Universidad
        {
            Nombre = "UTN", 
            Sigla = "FRSR"
        };

        Assert.NotNull(universidad);
        Assert.Equal("UTN",universidad.Nombre);
        Assert.Equal("FRSR",universidad.Sigla);
    }
}