using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class FacultadTests
{
    [Fact]
    public void FacultadTest()
    {
        var facultad = TestDataFactory.CreateFacultad();

        Assert.NotNull(facultad);
        Assert.Equal("Facultad de Sistemas",facultad.Nombre);
        Assert.Equal("Sist.",facultad.Abreviatura);
        Assert.Equal("Computación",facultad.Directorio);
        Assert.Equal("FS",facultad.Sigla);
        Assert.Equal("5600",facultad.CodigoPostal);
        Assert.Equal("San Rafael",facultad.Ciudad);
        Assert.Equal("Av Rivadavia 1234",facultad.Domicilio);
        Assert.Equal("123456789",facultad.Telefono);
        Assert.Equal("Pepito Juan",facultad.Contacto);
        Assert.Equal("utn@gmail.com",facultad.Email);

        Assert.NotNull(facultad.Universidad);
        Assert.Equal("UTN",facultad.Universidad.Nombre);
        Assert.Equal("FRSR",facultad.Universidad.Sigla);

        Assert.NotNull(facultad.Autoridades);
        Assert.Single(facultad.Autoridades);
        Assert.NotNull(facultad.Autoridades[0]);
        Assert.Equal("PruebaAutoridad",facultad.Autoridades[0].Nombre);
        Assert.Equal("rrhh",facultad.Autoridades[0].Cargo);
        Assert.Equal("1234553",facultad.Autoridades[0].Telefono);
        Assert.Equal("hguthg@gmail.com",facultad.Autoridades[0].Email);
    }
}