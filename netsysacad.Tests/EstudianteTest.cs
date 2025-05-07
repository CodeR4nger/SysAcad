using Xunit;
using netsysacad.Models;
namespace netsysacad.Tests;

public class EstudianteTests
{
    [Fact]
    public void EstudianteTest()
    {
        // Arrange
        var estudiante = new Estudiante
        {
            Id = 1,
            Nombre = "Juan",
            Apellido = "Pérez",
            Correo = "test@gmail.com",
            Telefono = "1234567890",
        };
        //Assert
        Assert.NotNull(estudiante);
        Assert.Equal(1, estudiante.Id);
        Assert.Equal("Juan", estudiante.Nombre);
        Assert.Equal("Pérez", estudiante.Apellido);
        Assert.Equal("test@gmail.com", estudiante.Correo);
        Assert.Equal("1234567890", estudiante.Telefono);
    }
}