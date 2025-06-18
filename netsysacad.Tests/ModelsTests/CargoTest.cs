using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Tests.Utils;

namespace netsysacad.Tests.ModelsTests
{
    public class CargoTests : EntityTestBase<Cargo, CargoService>
    {
        public CargoTests()
            : base(ctx => new CargoService(new CargoRepository(ctx))) { }

        protected override Cargo CreateEntity() => TestDataFactory.CreateCargo();

        protected override void CheckEntity(Cargo cargo)
        {
            Assert.NotNull(cargo);
            Assert.Equal("Profesor Titular", cargo.Nombre);
            Assert.Equal(100, cargo.Puntos);
            Assert.NotNull(cargo.CategoriaCargo);
            Assert.Equal("Administrativo", cargo.CategoriaCargo.Nombre);
            Assert.NotNull(cargo.TipoDedicacion);
            Assert.Equal("Exclusiva", cargo.TipoDedicacion.Nombre);
            Assert.Equal("Dedicación exclusiva a la docencia e investigación", cargo.TipoDedicacion.Observacion);
        }

        protected override Cargo Create(Cargo entity) => Service.Create(entity);
        protected override Cargo? GetById(int id) => Service.SearchById(id);
        protected override IList<Cargo> GetAll() => Service.SearchAll();
        protected override Cargo Update(Cargo entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Cargo entity) => entity.Id;
        protected override void ModifyEntity(Cargo entity)
        {
            entity.Nombre = "Suplente";
        }
        protected override void CheckUpdatedEntity(Cargo entity)
        {
            Assert.Equal("Suplente", entity.Nombre);
        }
    }
}