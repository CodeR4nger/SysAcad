using netsysacad.Models;
namespace netsysacad.Tests;

public class DepartamentoTests
{
    [Fact]
    public void DepartamentoTest()
     {
        var departamento = new Departamento
        {
            Nombre = "PruebaDepto", 
        };

        Assert.NotNull(departamento);
        Assert.Equal("PruebaDepto",departamento.Nombre);
    }
}