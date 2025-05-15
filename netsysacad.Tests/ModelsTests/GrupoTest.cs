using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.ModelsTests
{
    public class GrupoTests : EntityTestBase<Grupo, GrupoService>
    {
        public GrupoTests()
            : base(ctx => new GrupoService(new GrupoRepository(ctx))) { }

        protected override Grupo CreateEntity() => new()
        {
            Nombre = "Grupo A - 2025", 
        };

        protected override void CheckEntity(Grupo grupo)
        {
            Assert.NotNull(grupo);
            Assert.Equal("Grupo A - 2025",grupo.Nombre);
        }

        protected override Grupo Create(Grupo entity) => Service.Create(entity);
        protected override Grupo? GetById(int id) => Service.SearchById(id);
        protected override IList<Grupo> GetAll() => Service.SearchAll();
        protected override Grupo Update(Grupo entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Grupo entity) => entity.Id;
        protected override void ModifyEntity(Grupo entity)
        {
            entity.Nombre = "Grupo F - 2023";
        }
        protected override void CheckUpdatedEntity(Grupo entity)
        {
            Assert.Equal("Grupo F - 2023", entity.Nombre);
        }
    }
}