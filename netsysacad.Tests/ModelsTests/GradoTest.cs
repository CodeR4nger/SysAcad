using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.ModelsTests
{
    public class GradoTests : EntityTestBase<Grado, GradoService>
    {
        public GradoTests()
            : base(ctx => new GradoService(new GradoRepository(ctx))) { }

        protected override Grado CreateEntity() => new()
        {
            Nombre = "Licenciatura", 
        };

        protected override void CheckEntity(Grado grado)
        {
            Assert.NotNull(grado);
            Assert.Equal("Licenciatura",grado.Nombre);
        }

        protected override Grado Create(Grado entity) => Service.Create(entity);
        protected override Grado? GetById(int id) => Service.SearchById(id);
        protected override IList<Grado> GetAll() => Service.SearchAll();
        protected override Grado Update(Grado entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Grado entity) => entity.Id;
        protected override void ModifyEntity(Grado entity)
        {
            entity.Nombre = "Tecnicatura";
        }
        protected override void CheckUpdatedEntity(Grado entity)
        {
            Assert.Equal("Tecnicatura", entity.Nombre);
        }
    }
}