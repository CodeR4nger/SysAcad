using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.Models
{
    public class AreaTests : EntityTestBase<Area, AreaService>
    {
        public AreaTests()
            : base(ctx => new AreaService(new AreaRepository(ctx))) { }

        protected override Area CreateEntity() => new()
        {
            Nombre = "Ciencias de la Computación", 
        };

        protected override void CheckEntity(Area area)
        {
            Assert.NotNull(area);
            Assert.Equal("Ciencias de la Computación",area.Nombre);
        }

        protected override Area Create(Area entity) => Service.Create(entity);
        protected override Area? GetById(int id) => Service.SearchById(id);
        protected override IList<Area> GetAll() => Service.SearchAll();
        protected override Area Update(Area entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Area entity) => entity.Id;
        protected override void ModifyEntity(Area entity)
        {
            entity.Nombre = "Materias basicas";
        }
        protected override void CheckUpdatedEntity(Area entity)
        {
            Assert.Equal("Materias basicas", entity.Nombre);
        }
    }
}