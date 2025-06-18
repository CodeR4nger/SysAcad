using netsysacad.Tests.Utils;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.Models
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
            Assert.NotNull(materia.Orientaciones);
            Assert.Single(materia.Orientaciones);
            Assert.NotNull(materia.Orientaciones[0]);
            Assert.Equal("Ciencia de Datos",materia.Orientaciones[0].Nombre);

            Assert.NotNull(materia.Orientaciones[0].Especialidad);
            Assert.Equal("Ingeniería de Software", materia.Orientaciones[0].Especialidad.Nombre);
            Assert.Equal("S", materia.Orientaciones[0].Especialidad.Letra);
            Assert.Equal("Orientada al desarrollo de sistemas", materia.Orientaciones[0].Especialidad.Observacion);
            Assert.NotNull(materia.Orientaciones[0].Especialidad.TipoEspecialidad);
            Assert.Equal("Técnica", materia.Orientaciones[0].Especialidad.TipoEspecialidad.Nombre);
            Assert.Equal("Intermedio", materia.Orientaciones[0].Especialidad.TipoEspecialidad.Nivel);

            Assert.NotNull(materia.Orientaciones[0].Plan);
            Assert.Equal("Plan 2020",materia.Orientaciones[0].Plan.Nombre);
            Assert.Equal("2020-03-01",materia.Orientaciones[0].Plan.FechaInicio);
            Assert.Equal("2025-12-31",materia.Orientaciones[0].Plan.FechaFin);
            Assert.Equal("Plan de estudios vigente",materia.Orientaciones[0].Plan.Observacion);
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