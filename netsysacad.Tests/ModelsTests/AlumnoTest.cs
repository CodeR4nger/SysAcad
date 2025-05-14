using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
namespace netsysacad.Tests.ModelsTests;

public class AlumnoTests : TestBase
{
    protected readonly AlumnoService AlumnoService;
    public AlumnoTests()
    {
        var alumnoRepo = new AlumnoRepository(Context);
        AlumnoService = new AlumnoService(alumnoRepo);  
    }
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
    private static void CheckAlumno(Alumno alumno) {
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
    [Fact]
    public void AlumnoTest()
    {
        var alumno = CreateAlumno();
        CheckAlumno(alumno);
    }
    [Fact]
    public void CanCreateAlumno() 
    {
        var alumno = CreateAlumno();
        var createdAlumno = AlumnoService.Create(alumno);

        CheckAlumno(createdAlumno);
        Assert.True(createdAlumno.Id > 0);

    }
    [Fact]
    public void CanReadAlumno() 
    {
        var alumno = CreateAlumno();
        var createdAlumno = AlumnoService.Create(alumno);
        var searchedAlumno = AlumnoService.SearchById(createdAlumno.Id);
        CheckAlumno(searchedAlumno);
    }
    [Fact]
    public void CanReadAllAlumnos() 
    {
        var alumno1 = CreateAlumno();
        var alumno2 = CreateAlumno();
        AlumnoService.Create(alumno1);
        AlumnoService.Create(alumno2);
        var alumnos = AlumnoService.SearchAll();
        Assert.NotEmpty(alumnos);
        Assert.Equal(2, alumnos.Count);
        CheckAlumno(alumnos[0]);
    }
    [Fact]
    public void CanUpdateAlumno() 
    {
        var alumno = CreateAlumno();
        AlumnoService.Create(alumno);
        alumno.Apellido = "Sanchez";

        var updatedAlumno = AlumnoService.Update(alumno);

        Assert.Equal("Sanchez",updatedAlumno.Apellido);
        Assert.Equal(alumno.Id,updatedAlumno.Id);
    }
    [Fact]
    public void CanDeleteAlumno() 
    {
        var alumno = CreateAlumno();
        var createdAlumno = AlumnoService.Create(alumno);
        var wasDeleted = AlumnoService.DeleteById(createdAlumno.Id);
        Assert.True(wasDeleted);
        var searchedAlumno = AlumnoService.SearchById(createdAlumno.Id);
        Assert.Null(searchedAlumno);
    }
}