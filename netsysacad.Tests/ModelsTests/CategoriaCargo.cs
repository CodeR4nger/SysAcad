using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class CategoriaCargoTests
{
    [Fact]
    public void CategoriaCargoTest()
     {
        var categoriaCargo = TestDataFactory.CreateCategoriaCargo();

        Assert.NotNull(categoriaCargo);
        Assert.Equal("Administrativo",categoriaCargo.Nombre);
    }
}