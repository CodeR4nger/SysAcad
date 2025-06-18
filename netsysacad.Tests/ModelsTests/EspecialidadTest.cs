using netsysacad.Tests.Utils;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.ModelsTests
{
    public class EspecialidadTests : EntityTestBase<Especialidad, EspecialidadService>
    {
        public EspecialidadTests()
            : base(ctx => new EspecialidadService(new EspecialidadRepository(ctx))) { }

        protected override Especialidad CreateEntity() => TestDataFactory.CreateEspecialidad();

        protected override void CheckEntity(Especialidad especialidad)
        {
            Assert.NotNull(especialidad);
            Assert.Equal("Ingeniería de Software", especialidad.Nombre);
            Assert.Equal("S", especialidad.Letra);
            Assert.Equal("Orientada al desarrollo de sistemas", especialidad.Observacion);
            Assert.NotNull(especialidad.TipoEspecialidad);
            Assert.Equal("Técnica", especialidad.TipoEspecialidad.Nombre);
            Assert.Equal("Intermedio", especialidad.TipoEspecialidad.Nivel);
        }

        protected override Especialidad Create(Especialidad entity) => Service.Create(entity);
        protected override Especialidad? GetById(int id) => Service.SearchById(id);
        protected override IList<Especialidad> GetAll() => Service.SearchAll();
        protected override Especialidad Update(Especialidad entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Especialidad entity) => entity.Id;
        protected override void ModifyEntity(Especialidad entity)
        {
            entity.Letra = "J";
        }
        protected override void CheckUpdatedEntity(Especialidad entity)
        {
            Assert.Equal("J", entity.Letra);
        }
    }
}