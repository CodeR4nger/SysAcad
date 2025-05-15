using netsysacad.Tests.Helpers;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.ModelsTests
{
    public class MateriaTests : EntityTestBase<Materia, MateriaService>
    {
        public MateriaTests()
            : base(ctx => new MateriaService(new MateriaRepository(ctx))) { }

        protected override Materia CreateEntity() => TestDataFactory.CreateMateria();
        protected override void CheckEntity(Materia materia)
        {
            Assert.NotNull(materia);
            Assert.Equal("Desarrollo de software",materia.Nombre);
            Assert.Equal("102",materia.Codigo);
            Assert.Equal("Ninguna observacion",materia.Observacion);
        }

        protected override Materia Create(Materia entity) => Service.Create(entity);
        protected override Materia? GetById(int id) => Service.SearchById(id);
        protected override IList<Materia> GetAll() => Service.SearchAll();
        protected override Materia Update(Materia entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Materia entity) => entity.Id;
        protected override void ModifyEntity(Materia entity)
        {
            entity.Nombre = "Economia";
        }
        protected override void CheckUpdatedEntity(Materia entity)
        {
            Assert.Equal("Economia", entity.Nombre);
        }
    }
}