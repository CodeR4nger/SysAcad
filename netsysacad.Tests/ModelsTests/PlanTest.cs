using netsysacad.Tests.Utils;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.ModelsTests
{
    public class PlanTests : EntityTestBase<Plan, PlanService>
    {
        public PlanTests()
            : base(ctx => new PlanService(new PlanRepository(ctx))) { }

        protected override Plan CreateEntity() => TestDataFactory.CreatePlan();

        protected override void CheckEntity(Plan plan)
        {
            Assert.NotNull(plan);
            Assert.Equal("Plan 2020",plan.Nombre);
            Assert.Equal("2020-03-01",plan.FechaInicio);
            Assert.Equal("2025-12-31",plan.FechaFin);
            Assert.Equal("Plan de estudios vigente",plan.Observacion);
        }

        protected override Plan Create(Plan entity) => Service.Create(entity);
        protected override Plan? GetById(int id) => Service.SearchById(id);
        protected override IList<Plan> GetAll() => Service.SearchAll();
        protected override Plan Update(Plan entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Plan entity) => entity.Id;
        protected override void ModifyEntity(Plan entity)
        {
            entity.Nombre = "Plan 2024";
        }
        protected override void CheckUpdatedEntity(Plan entity)
        {
            Assert.Equal("Plan 2024", entity.Nombre);
        }
    }
}