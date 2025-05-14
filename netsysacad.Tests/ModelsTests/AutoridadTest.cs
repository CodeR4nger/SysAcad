using netsysacad.Tests.Helpers;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Models;
namespace netsysacad.Tests.ModelsTests;

public class AutoridadTests : TestBase
{
    protected readonly AutoridadService AutoridadService;
    public AutoridadTests()
    {
        var autoridadRepo = new AutoridadRepository(Context);
        AutoridadService = new AutoridadService(autoridadRepo);  
    }
    private static void CheckAutoridad(Autoridad autoridad)
    {
        Assert.NotNull(autoridad);
        Assert.Equal("PruebaAutoridad",autoridad.Nombre);
        Assert.NotNull(autoridad.Cargo);
        Assert.NotNull(autoridad.Cargo);
        Assert.Equal("Profesor Titular", autoridad.Cargo.Nombre);
        Assert.Equal(100, autoridad.Cargo.Puntos);
        Assert.NotNull(autoridad.Cargo.CategoriaCargo);
        Assert.Equal("Administrativo", autoridad.Cargo.CategoriaCargo.Nombre);
        Assert.NotNull(autoridad.Cargo.TipoDedicacion);
        Assert.Equal("Exclusiva", autoridad.Cargo.TipoDedicacion.Nombre);
        Assert.Equal("Dedicación exclusiva a la docencia e investigación", autoridad.Cargo.TipoDedicacion.Observacion);
        Assert.Equal("1234553",autoridad.Telefono);
        Assert.Equal("hguthg@gmail.com",autoridad.Email);
    }
    [Fact]
    public void AutoridadTest()
     {
        var autoridad =  TestDataFactory.CreateAutoridad();
        CheckAutoridad(autoridad);
    }
    [Fact]
    public void CanCreateAutoridad() 
    {
        var autoridad = TestDataFactory.CreateAutoridad();
        var createdAutoridad = AutoridadService.Create(autoridad);
        CheckAutoridad(createdAutoridad);
        Assert.True(createdAutoridad.Id > 0);

    }
    [Fact]
    public void CanReadAutoridad() 
    {
        var autoridad = TestDataFactory.CreateAutoridad();
        var createdAutoridad = AutoridadService.Create(autoridad);
        var searchedAutoridad = AutoridadService.SearchById(createdAutoridad.Id);
        Assert.Equal(createdAutoridad.Id,searchedAutoridad.Id);
        CheckAutoridad(searchedAutoridad);
    }
    [Fact]
    public void CanReadAllAutoridades() 
    {
        var autoridad1 = TestDataFactory.CreateAutoridad();
        var autoridad2 = TestDataFactory.CreateAutoridad();
        AutoridadService.Create(autoridad1);
        AutoridadService.Create(autoridad2);
        var autoridades = AutoridadService.SearchAll();
        Assert.NotEmpty(autoridades);
        Assert.Equal(2, autoridades.Count);
        CheckAutoridad(autoridades[0]);
    }
    [Fact]
    public void CanUpdateAutoridad() 
    {
        var autoridad = TestDataFactory.CreateAutoridad();
        AutoridadService.Create(autoridad);
        autoridad.Nombre = "Materias basicas";

        var updatedAutoridad = AutoridadService.Update(autoridad);

        Assert.Equal("Materias basicas",updatedAutoridad.Nombre);
        Assert.Equal(autoridad.Id,updatedAutoridad.Id);
    }
    [Fact]
    public void CanDeleteAutoridad() 
    {
        var autoridad = TestDataFactory.CreateAutoridad();
        var createdAutoridad = AutoridadService.Create(autoridad);
        var wasDeleted = AutoridadService.DeleteById(createdAutoridad.Id);
        Assert.True(wasDeleted);
        var searchedAutoridad = AutoridadService.SearchById(createdAutoridad.Id);
        Assert.Null(searchedAutoridad);
    }
}