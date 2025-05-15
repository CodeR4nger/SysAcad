using netsysacad.Tests.Helpers;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.ModelsTests
{
    public class CategoriaCargoTests : EntityTestBase<CategoriaCargo, CategoriaCargoService>
    {
        public CategoriaCargoTests()
            : base(ctx => new CategoriaCargoService(new CategoriaCargoRepository(ctx))) { }

        protected override CategoriaCargo CreateEntity() => TestDataFactory.CreateCategoriaCargo();

        protected override void CheckEntity(CategoriaCargo categoriaCargo)
        {
            Assert.NotNull(categoriaCargo);
            Assert.Equal("Administrativo",categoriaCargo.Nombre);
        }

        protected override CategoriaCargo Create(CategoriaCargo entity) => Service.Create(entity);
        protected override CategoriaCargo? GetById(int id) => Service.SearchById(id);
        protected override IList<CategoriaCargo> GetAll() => Service.SearchAll();
        protected override CategoriaCargo Update(CategoriaCargo entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(CategoriaCargo entity) => entity.Id;
        protected override void ModifyEntity(CategoriaCargo entity)
        {
            entity.Nombre = "Educativo";
        }
        protected override void CheckUpdatedEntity(CategoriaCargo entity)
        {
            Assert.Equal("Educativo", entity.Nombre);
        }
    }
}