using netsysacad.Tests.Helpers;
namespace netsysacad.Tests.ModelsTests;

public class PlanTests
{
    [Fact]
    public void PlanTest()
     {
        var plan = TestDataFactory.CreatePlan();

        Assert.NotNull(plan);
        Assert.Equal("Plan 2020",plan.Nombre);
        Assert.Equal("2020-03-01",plan.FechaInicio);
        Assert.Equal("2025-12-31",plan.FechaFin);
        Assert.Equal("Plan de estudios vigente",plan.Observacion);
    }
}