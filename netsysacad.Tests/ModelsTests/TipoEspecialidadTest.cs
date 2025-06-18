using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Tests.Utils;

namespace netsysacad.Tests.ModelsTests
{
    public class TipoEspecialidadTests : EntityTestBase<TipoEspecialidad, TipoEspecialidadService>
    {
        public TipoEspecialidadTests()
            : base(ctx => new TipoEspecialidadService(new TipoEspecialidadRepository(ctx))) { }

        protected override TipoEspecialidad CreateEntity() => TestDataFactory.CreateTipoEspecialidad();

        protected override void CheckEntity(TipoEspecialidad tipoEspecialidad)
        {
            Assert.NotNull(tipoEspecialidad);
            Assert.Equal("Técnica", tipoEspecialidad.Nombre);
            Assert.Equal("Intermedio", tipoEspecialidad.Nivel);
        }

        protected override TipoEspecialidad Create(TipoEspecialidad entity) => Service.Create(entity);
        protected override TipoEspecialidad? GetById(int id) => Service.SearchById(id);
        protected override IList<TipoEspecialidad> GetAll() => Service.SearchAll();
        protected override TipoEspecialidad Update(TipoEspecialidad entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(TipoEspecialidad entity) => entity.Id;
        protected override void ModifyEntity(TipoEspecialidad entity)
        {
            entity.Nivel = "Avanzado";
        }
        protected override void CheckUpdatedEntity(TipoEspecialidad entity)
        {
            Assert.Equal("Avanzado", entity.Nivel);
        }
    }
}