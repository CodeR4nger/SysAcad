using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
namespace netsysacad.Tests.ModelsTests;

public class AreaTests : TestBase
{
    protected readonly AreaService AreaService;
    public AreaTests()
    {
        var areaRepo = new AreaRepository(Context);
        AreaService = new AreaService(areaRepo);  
    }
    private static Area CreateArea() => new()
    {
        Nombre = "Ciencias de la Computación", 
    };
    private static void CheckArea(Area area)
    {
        Assert.NotNull(area);
        Assert.Equal("Ciencias de la Computación",area.Nombre);
    }
    [Fact]
    public void AreaTest()
     {
        var area = CreateArea();

    }
        [Fact]
    public void CanCreateArea() 
    {
        var area = CreateArea();
        var createdArea = AreaService.Create(area);
        CheckArea(createdArea);
        Assert.True(createdArea.Id > 0);

    }
    [Fact]
    public void CanReadArea() 
    {
        var area = CreateArea();
        var createdArea = AreaService.Create(area);
        var searchedArea = AreaService.SearchById(createdArea.Id);
        Assert.Equal(createdArea.Id,searchedArea.Id);
        CheckArea(searchedArea);
    }
    [Fact]
    public void CanReadAllAreas() 
    {
        var area1 = CreateArea();
        var area2 = CreateArea();
        AreaService.Create(area1);
        AreaService.Create(area2);
        var areas = AreaService.SearchAll();
        Assert.NotEmpty(areas);
        Assert.Equal(2, areas.Count);
        CheckArea(areas[0]);
    }
    [Fact]
    public void CanUpdateAreas() 
    {
        var area = CreateArea();
        AreaService.Create(area);
        area.Nombre = "Materias basicas";

        var updatedArea = AreaService.Update(area);

        Assert.Equal("Materias basicas",updatedArea.Nombre);
        Assert.Equal(area.Id,updatedArea.Id);
    }
    [Fact]
    public void CanDeleteArea() 
    {
        var area = CreateArea();
        var createdArea = AreaService.Create(area);
        var wasDeleted = AreaService.DeleteById(createdArea.Id);
        Assert.True(wasDeleted);
        var searchedArea = AreaService.SearchById(createdArea.Id);
        Assert.Null(searchedArea);
    }
}