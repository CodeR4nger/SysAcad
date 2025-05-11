using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class UniversidadTests
{
    [Fact]
    public void UniversidadTest()
     {
        var universidad = TestDataFactory.CreateUniversidad();

        Assert.NotNull(universidad);
        Assert.Equal("UTN",universidad.Nombre);
        Assert.Equal("FRSR",universidad.Sigla);
    }
}