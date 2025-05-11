using netsysacad.Models;
namespace netsysacad.Tests.ModelsTests;

public class AlumnoTests
{
    private static Alumno CreateAlumno() => new()
        {
            Apellido = "Gomez", 
            Nombre = "Juan", 
            NroDocumento = "12345678", 
            TipoDocumento = TipoDocumento.DNI, 
            FechaNacimiento = "2000-01-01", 
            Sexo = "M", 
            NroLegajo = 1001, 
            FechaIngreso = new DateTime(2020, 3, 1)
    };
    [Fact]
    public void AlumnoTest()
     {
        var alumno = CreateAlumno();
        Assert.NotNull(alumno);
        Assert.Equal("Gomez", alumno.Apellido);
        Assert.Equal("Juan", alumno.Nombre);
        Assert.Equal("12345678", alumno.NroDocumento);
        Assert.Equal(TipoDocumento.DNI, alumno.TipoDocumento);
        Assert.Equal("2000-01-01", alumno.FechaNacimiento);
        Assert.Equal("M", alumno.Sexo);
        Assert.Equal(1001, alumno.NroLegajo);
        Assert.Equal(new DateTime(2020, 3, 1), alumno.FechaIngreso);
    }
}