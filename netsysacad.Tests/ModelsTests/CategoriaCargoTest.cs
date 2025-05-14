using netsysacad.Tests.Helpers;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
namespace netsysacad.Tests.ModelsTests;

public class CategoriaCargoTests : TestBase
{
    protected readonly CategoriaCargoService CategoriaCargoService;
    public CategoriaCargoTests()
    {
        var categoriaCargoRepo = new CategoriaCargoRepository(Context);
        CategoriaCargoService = new CategoriaCargoService(categoriaCargoRepo);  
    }
    private static void CheckCategoriaCargo(CategoriaCargo categoriaCargo)
    {
        Assert.NotNull(categoriaCargo);
        Assert.Equal("Administrativo",categoriaCargo.Nombre);
    }
    [Fact]
    public void CategoriaCargoTest()
     {
        var categoriaCargo = TestDataFactory.CreateCategoriaCargo();
        CheckCategoriaCargo(categoriaCargo);
    }
    [Fact]
    public void CanCreateCategoriaCargo() 
    {
        var categoriaCargo = TestDataFactory.CreateCategoriaCargo();
        var createdCategoriaCargo = CategoriaCargoService.Create(categoriaCargo);
        CheckCategoriaCargo(createdCategoriaCargo);
        Assert.True(createdCategoriaCargo.Id > 0);

    }
    [Fact]
    public void CanReadCategoriaCargo() 
    {
        var categoriaCargo = TestDataFactory.CreateCategoriaCargo();
        var createdCategoriaCargo = CategoriaCargoService.Create(categoriaCargo);
        var searchedCategoriaCargo = CategoriaCargoService.SearchById(createdCategoriaCargo.Id);
        Assert.Equal(createdCategoriaCargo.Id,searchedCategoriaCargo.Id);
        CheckCategoriaCargo(searchedCategoriaCargo);
    }
    [Fact]
    public void CanReadAllCategoriaCargos() 
    {
        var categoriaCargo1 = TestDataFactory.CreateCategoriaCargo();
        var categoriaCargo2 = TestDataFactory.CreateCategoriaCargo();
        CategoriaCargoService.Create(categoriaCargo1);
        CategoriaCargoService.Create(categoriaCargo2);
        var categoriaCargos = CategoriaCargoService.SearchAll();
        Assert.NotEmpty(categoriaCargos);
        Assert.Equal(2, categoriaCargos.Count);
        CheckCategoriaCargo(categoriaCargos[0]);
    }
    [Fact]
    public void CanUpdateCategoriaCargos() 
    {
        var categoriaCargo = TestDataFactory.CreateCategoriaCargo();
        CategoriaCargoService.Create(categoriaCargo);
        categoriaCargo.Nombre = "Educativo";

        var updatedCategoriaCargo = CategoriaCargoService.Update(categoriaCargo);

        Assert.Equal("Educativo",updatedCategoriaCargo.Nombre);
        Assert.Equal(categoriaCargo.Id,updatedCategoriaCargo.Id);
    }
    [Fact]
    public void CanDeleteCategoriaCargo() 
    {
        var categoriaCargo = TestDataFactory.CreateCategoriaCargo();
        var createdCategoriaCargo = CategoriaCargoService.Create(categoriaCargo);
        var wasDeleted = CategoriaCargoService.DeleteById(createdCategoriaCargo.Id);
        Assert.True(wasDeleted);
        var searchedCategoriaCargo = CategoriaCargoService.SearchById(createdCategoriaCargo.Id);
        Assert.Null(searchedCategoriaCargo);
    }
}