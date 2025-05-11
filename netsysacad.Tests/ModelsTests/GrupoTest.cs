using netsysacad.Models;
namespace netsysacad.Tests.ModelsTests;

public class GrupoTests
{
    private static Grupo CreateGrupo()
    {
        return new Grupo
        {
            Nombre = "Grupo A - 2025", 
        };
    }
    [Fact]
    public void GrupoTest()
     {
        var grupo = CreateGrupo(); 

        Assert.NotNull(grupo);
        Assert.Equal("Grupo A - 2025",grupo.Nombre);
    }
}