using netsysacad.Models;
namespace netsysacad.Tests.ModelsTests;

public class AreaTests
{
    private static Area CreateArea() => new()
    {
        Nombre = "Ciencias de la Computación", 
    };
    [Fact]
    public void AreaTest()
     {
        var area = CreateArea();
        Assert.NotNull(area);
        Assert.Equal("Ciencias de la Computación",area.Nombre);
    }
}