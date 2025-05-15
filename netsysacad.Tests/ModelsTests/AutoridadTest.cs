using netsysacad.Tests.Helpers;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Models;

namespace netsysacad.Tests.ModelsTests
{
    public class AutoridadTests : EntityTestBase<Autoridad, AutoridadService>
    {
        public AutoridadTests()
            : base(ctx => new AutoridadService(new AutoridadRepository(ctx))) { }

        protected override Autoridad CreateEntity() => TestDataFactory.CreateAutoridad();


        protected override void CheckEntity(Autoridad autoridad)
        {
            Assert.NotNull(autoridad);
            Assert.Equal("PruebaAutoridad",autoridad.Nombre);
            Assert.NotNull(autoridad.Cargo);
            Assert.NotNull(autoridad.Cargo);
            Assert.Equal("Profesor Titular", autoridad.Cargo.Nombre);
            Assert.Equal(100, autoridad.Cargo.Puntos);
            Assert.NotNull(autoridad.Cargo.CategoriaCargo);
            Assert.Equal("Administrativo", autoridad.Cargo.CategoriaCargo.Nombre);
            Assert.NotNull(autoridad.Cargo.TipoDedicacion);
            Assert.Equal("Exclusiva", autoridad.Cargo.TipoDedicacion.Nombre);
            Assert.Equal("Dedicación exclusiva a la docencia e investigación", autoridad.Cargo.TipoDedicacion.Observacion);
            Assert.Equal("1234553",autoridad.Telefono);
            Assert.Equal("hguthg@gmail.com",autoridad.Email);
        }

        protected override Autoridad Create(Autoridad entity) => Service.Create(entity);
        protected override Autoridad? GetById(int id) => Service.SearchById(id);
        protected override IList<Autoridad> GetAll() => Service.SearchAll();
        protected override Autoridad Update(Autoridad entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Autoridad entity) => entity.Id;
        protected override void ModifyEntity(Autoridad entity)
        {
            entity.Nombre = "Decano";
        }
        protected override void CheckUpdatedEntity(Autoridad entity)
        {
            Assert.Equal("Decano", entity.Nombre);
        }
    }
}