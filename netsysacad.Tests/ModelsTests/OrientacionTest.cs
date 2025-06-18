using netsysacad.Tests.Utils;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.ModelsTests
{
    public class OrientacionTests : EntityTestBase<Orientacion, OrientacionService>
    {
        public OrientacionTests()
            : base(ctx => new OrientacionService(new OrientacionRepository(ctx))) { }

        protected override Orientacion CreateEntity() => TestDataFactory.CreateOrientacion();

        protected override void CheckEntity(Orientacion orientacion)
        {
            Assert.NotNull(orientacion);
            Assert.Equal("Ciencia de Datos",orientacion.Nombre);

            Assert.NotNull(orientacion.Especialidad);
            Assert.Equal("Ingeniería de Software", orientacion.Especialidad.Nombre);
            Assert.Equal("S", orientacion.Especialidad.Letra);
            Assert.Equal("Orientada al desarrollo de sistemas", orientacion.Especialidad.Observacion);
            Assert.NotNull(orientacion.Especialidad.TipoEspecialidad);
            Assert.Equal("Técnica", orientacion.Especialidad.TipoEspecialidad.Nombre);
            Assert.Equal("Intermedio", orientacion.Especialidad.TipoEspecialidad.Nivel);

            Assert.NotNull(orientacion.Plan);
            Assert.Equal("Plan 2020",orientacion.Plan.Nombre);
            Assert.Equal("2020-03-01",orientacion.Plan.FechaInicio);
            Assert.Equal("2025-12-31",orientacion.Plan.FechaFin);
            Assert.Equal("Plan de estudios vigente",orientacion.Plan.Observacion);

            Assert.NotNull(orientacion.Materias);
            Assert.Single(orientacion.Materias);
            Assert.NotNull(orientacion.Materias[0]);
            Assert.Equal("Desarrollo de software",orientacion.Materias[0].Nombre);
            Assert.Equal("102",orientacion.Materias[0].Codigo);
            Assert.Equal("Ninguna observacion",orientacion.Materias[0].Observacion);
        }

        protected override Orientacion Create(Orientacion entity) => Service.Create(entity);
        protected override Orientacion? GetById(int id) => Service.SearchById(id);
        protected override IList<Orientacion> GetAll() => Service.SearchAll();
        protected override Orientacion Update(Orientacion entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Orientacion entity) => entity.Id;
        protected override void ModifyEntity(Orientacion entity)
        {
            entity.Nombre = "Ciencias naturales";
        }
        protected override void CheckUpdatedEntity(Orientacion entity)
        {
            Assert.Equal("Ciencias naturales", entity.Nombre);
        }
    }
}