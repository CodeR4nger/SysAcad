using netsysacad.Models;
namespace netsysacad.Tests;

public class FacultadTests
{
    [Fact]
    public void FacultadTest()
    {
        var facultad = new Facultad
        {
            Nombre = "Facultad de Sistemas", 
            Abreviatura = "Sist.",
            Directorio = "A",
            Sigla = "FS",
            CodigoPostal = "5600",
            Ciudad = "San Rafael",
            Domicilio = "Av Rivadavia 1234",
            Telefono = "123456789",
            Contacto = "B",
            Email = "utn@gmail.com"
        };

        Assert.NotNull(facultad);
        Assert.Equal("Facultad de Sistemas",facultad.Nombre);
        Assert.Equal("Sist.",facultad.Abreviatura);
        Assert.Equal("A",facultad.Directorio);
        Assert.Equal("FS",facultad.Sigla);
        Assert.Equal("5600",facultad.CodigoPostal);
        Assert.Equal("San Rafael",facultad.Ciudad);
        Assert.Equal("Av Rivadavia 1234",facultad.Domicilio);
        Assert.Equal("123456789",facultad.Telefono);
        Assert.Equal("B",facultad.Contacto);
        Assert.Equal("utn@gmail.com",facultad.Email);
    }
}