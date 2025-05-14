using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class CargoTests : TestBase
{
    protected readonly CargoService CargoService;
    public CargoTests()
    {
        var cargoRepo = new CargoRepository(Context);
        CargoService = new CargoService(cargoRepo);  
    }
    private static void CheckCargo(Cargo cargo)
    {
        Assert.NotNull(cargo);
        Assert.Equal("Profesor Titular", cargo.Nombre);
        Assert.Equal(100, cargo.Puntos);
        Assert.NotNull(cargo.CategoriaCargo);
        Assert.Equal("Administrativo", cargo.CategoriaCargo.Nombre);
        Assert.NotNull(cargo.TipoDedicacion);
        Assert.Equal("Exclusiva", cargo.TipoDedicacion.Nombre);
        Assert.Equal("Dedicación exclusiva a la docencia e investigación", cargo.TipoDedicacion.Observacion);
    }
    [Fact]
    public void CargoTest()
    {
        var cargo = TestDataFactory.CreateCargo();
        CheckCargo(cargo);
    }
    [Fact]
    public void CanCreateCargo() 
    {
        var cargo = TestDataFactory.CreateCargo();
        var createdCargo = CargoService.Create(cargo);
        CheckCargo(createdCargo);
        Assert.True(createdCargo.Id > 0);

    }
    [Fact]
    public void CanReadCargo() 
    {
        var cargo = TestDataFactory.CreateCargo();
        var createdCargo = CargoService.Create(cargo);
        var searchedCargo = CargoService.SearchById(createdCargo.Id);
        Assert.Equal(createdCargo.Id,searchedCargo.Id);
        CheckCargo(searchedCargo);
    }
    [Fact]
    public void CanReadAllCargoes() 
    {
        var cargo1 = TestDataFactory.CreateCargo();
        var cargo2 = TestDataFactory.CreateCargo();
        CargoService.Create(cargo1);
        CargoService.Create(cargo2);
        var cargoes = CargoService.SearchAll();
        Assert.NotEmpty(cargoes);
        Assert.Equal(2, cargoes.Count);
        CheckCargo(cargoes[0]);
    }
    [Fact]
    public void CanUpdateCargo() 
    {
        var cargo = TestDataFactory.CreateCargo();
        CargoService.Create(cargo);
        cargo.Nombre = "Suplente";

        var updatedCargo = CargoService.Update(cargo);

        Assert.Equal("Suplente",updatedCargo.Nombre);
        Assert.Equal(cargo.Id,updatedCargo.Id);
    }
    [Fact]
    public void CanDeleteCargo() 
    {
        var cargo = TestDataFactory.CreateCargo();
        var createdCargo = CargoService.Create(cargo);
        var wasDeleted = CargoService.DeleteById(createdCargo.Id);
        Assert.True(wasDeleted);
        var searchedCargo = CargoService.SearchById(createdCargo.Id);
        Assert.Null(searchedCargo);
    }
}