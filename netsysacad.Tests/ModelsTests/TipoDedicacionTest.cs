using netsysacad.Tests.Helpers;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Models;

namespace netsysacad.Tests.ModelsTests
{
    public class TipoDedicacionTests : EntityTestBase<TipoDedicacion, TipoDedicacionService>
    {
        public TipoDedicacionTests()
            : base(ctx => new TipoDedicacionService(new TipoDedicacionRepository(ctx))) { }

        protected override TipoDedicacion CreateEntity() => TestDataFactory.CreateTipoDedicacion();

        protected override void CheckEntity(TipoDedicacion tipoDedicacion)
        {
            Assert.Equal("Exclusiva",tipoDedicacion.Nombre);
            Assert.Equal("Dedicación exclusiva a la docencia e investigación", tipoDedicacion.Observacion);
        }

        protected override TipoDedicacion Create(TipoDedicacion entity) => Service.Create(entity);
        protected override TipoDedicacion GetById(int id) => Service.SearchById(id);
        protected override IList<TipoDedicacion> GetAll() => Service.SearchAll();
        protected override TipoDedicacion Update(TipoDedicacion entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(TipoDedicacion entity) => entity.Id;
        protected override void ModifyEntity(TipoDedicacion entity)
        {
            entity.Nombre = "General";
        }
        protected override void CheckUpdatedEntity(TipoDedicacion entity)
        {
            Assert.Equal("General", entity.Nombre);
        }
    }
}