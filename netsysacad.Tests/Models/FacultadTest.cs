using netsysacad.Tests.Utils;
using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;

namespace netsysacad.Tests.Models
{
    public class FacultadTests : EntityTestBase<Facultad, FacultadService>
    {
        public FacultadTests()
            : base(ctx => new FacultadService(new FacultadRepository(ctx))) { }

        protected override Facultad CreateEntity() => TestDataFactory.CreateFacultad();

        protected override void CheckEntity(Facultad facultad)
        {
            Assert.NotNull(facultad);
            Assert.Equal("Facultad de Sistemas",facultad.Nombre);
            Assert.Equal("Sist.",facultad.Abreviatura);
            Assert.Equal("Computación",facultad.Directorio);
            Assert.Equal("FS",facultad.Sigla);
            Assert.Equal("5600",facultad.CodigoPostal);
            Assert.Equal("San Rafael",facultad.Ciudad);
            Assert.Equal("Av Rivadavia 1234",facultad.Domicilio);
            Assert.Equal("123456789",facultad.Telefono);
            Assert.Equal("Pepito Juan",facultad.Contacto);
            Assert.Equal("utn@gmail.com",facultad.Email);

            Assert.NotNull(facultad.Universidad);
            Assert.Equal("UTN",facultad.Universidad.Nombre);
            Assert.Equal("FRSR",facultad.Universidad.Sigla);
        }

        protected override Facultad Create(Facultad entity) => Service.Create(entity);
        protected override Facultad? GetById(int id) => Service.SearchById(id);
        protected override IList<Facultad> GetAll() => Service.SearchAll();
        protected override Facultad Update(Facultad entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Facultad entity) => entity.Id;
        protected override void ModifyEntity(Facultad entity)
        {
            entity.Nombre = "Facultad F - 2023";
        }
        protected override void CheckUpdatedEntity(Facultad entity)
        {
            Assert.Equal("Facultad F - 2023", entity.Nombre);
        }
    }
}