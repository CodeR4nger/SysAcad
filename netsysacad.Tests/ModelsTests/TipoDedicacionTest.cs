using netsysacad.Tests.Helpers;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Models;

namespace netsysacad.Tests.ModelsTests;

public class TipoDedicacionTests : TestBase
{
    protected readonly TipoDedicacionService TipoDedicacionService;
    public TipoDedicacionTests()
    {
        var tipoDedicacionRepo = new TipoDedicacionRepository(Context);
        TipoDedicacionService = new TipoDedicacionService(tipoDedicacionRepo);  
    }
    private static void CheckTipoDedicacion(TipoDedicacion tipoDedicacion)
    {
        Assert.Equal("Exclusiva",tipoDedicacion.Nombre);
        Assert.Equal("Dedicación exclusiva a la docencia e investigación", tipoDedicacion.Observacion);
    }
    [Fact]
    public void TipoDedicacionTest()
     {
        var tipoDedicacion = TestDataFactory.CreateTipoDedicacion();

        Assert.NotNull(tipoDedicacion);
    }
    [Fact]
    public void CanCreateTipoDedicacion() 
    {
        var tipoDedicacion = TestDataFactory.CreateTipoDedicacion();
        var createdTipoDedicacion = TipoDedicacionService.Create(tipoDedicacion);
        CheckTipoDedicacion(createdTipoDedicacion);
        Assert.True(createdTipoDedicacion.Id > 0);

    }
    [Fact]
    public void CanReadTipoDedicacion() 
    {
        var tipoDedicacion = TestDataFactory.CreateTipoDedicacion();
        var createdTipoDedicacion = TipoDedicacionService.Create(tipoDedicacion);
        var searchedTipoDedicacion = TipoDedicacionService.SearchById(createdTipoDedicacion.Id);
        Assert.Equal(createdTipoDedicacion.Id,searchedTipoDedicacion.Id);
        CheckTipoDedicacion(searchedTipoDedicacion);
    }
    [Fact]
    public void CanReadAllTiposDedicacion() 
    {
        var tipoDedicacion1 = TestDataFactory.CreateTipoDedicacion();
        var tipoDedicacion2 = TestDataFactory.CreateTipoDedicacion();
        TipoDedicacionService.Create(tipoDedicacion1);
        TipoDedicacionService.Create(tipoDedicacion2);
        var tipoDedicacions = TipoDedicacionService.SearchAll();
        Assert.NotEmpty(tipoDedicacions);
        Assert.Equal(2, tipoDedicacions.Count);
        CheckTipoDedicacion(tipoDedicacions[0]);
    }
    [Fact]
    public void CanUpdateTiposDedicacion() 
    {
        var tipoDedicacion = TestDataFactory.CreateTipoDedicacion();
        TipoDedicacionService.Create(tipoDedicacion);
        tipoDedicacion.Nombre = "Educativo";

        var updatedTipoDedicacion = TipoDedicacionService.Update(tipoDedicacion);

        Assert.Equal("Educativo",updatedTipoDedicacion.Nombre);
        Assert.Equal(tipoDedicacion.Id,updatedTipoDedicacion.Id);
    }
    [Fact]
    public void CanDeleteTipoDedicacion() 
    {
        var tipoDedicacion = TestDataFactory.CreateTipoDedicacion();
        var createdTipoDedicacion = TipoDedicacionService.Create(tipoDedicacion);
        var wasDeleted = TipoDedicacionService.DeleteById(createdTipoDedicacion.Id);
        Assert.True(wasDeleted);
        var searchedTipoDedicacion = TipoDedicacionService.SearchById(createdTipoDedicacion.Id);
        Assert.Null(searchedTipoDedicacion);
    }
}