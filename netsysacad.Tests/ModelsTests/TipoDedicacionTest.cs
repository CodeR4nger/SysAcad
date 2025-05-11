using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class TipoDedicacionTests
{
    [Fact]
    public void TipoDedicacionTest()
     {
        var tipoDedicacion = TestDataFactory.CreateTipoDedicacion();

        Assert.NotNull(tipoDedicacion);
        Assert.Equal("Exclusiva",tipoDedicacion.Nombre);
        Assert.Equal("Dedicación exclusiva a la docencia e investigación", tipoDedicacion.Observacion);
    }
}