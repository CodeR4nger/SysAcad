using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class CargoTests
{
    [Fact]
    public void CargoTest()
    {
        var cargo = TestDataFactory.CreateCargo();
        Assert.NotNull(cargo);
        Assert.Equal("Profesor Titular", cargo.Nombre);
        Assert.Equal(100, cargo.Puntos);
        Assert.NotNull(cargo.CategoriaCargo);
        Assert.Equal("Administrativo", cargo.CategoriaCargo.Nombre);
        Assert.NotNull(cargo.TipoDedicacion);
        Assert.Equal("Exclusiva", cargo.TipoDedicacion.Nombre);
        Assert.Equal("Dedicación exclusiva a la docencia e investigación", cargo.TipoDedicacion.Observacion);
    }
}