using netsysacad.Models;
namespace netsysacad.Tests.ModelsTests;

public class DepartamentoTests
{
    private static Departamento CreateDepartamento()
    {
        return new Departamento
        {
            Nombre = "Departamento de Sistemas", 
        };
    }
    [Fact]
    public void DepartamentoTest()
     {
        var departamento = CreateDepartamento();
        Assert.NotNull(departamento);
        Assert.Equal("Departamento de Sistemas",departamento.Nombre);
    }
}