using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Tests.Utils;

namespace netsysacad.Tests.Models
{
    public class AlumnoTests : EntityTestBase<Alumno, AlumnoService>
    {
        public AlumnoTests()
            : base(ctx => new AlumnoService(new AlumnoRepository(ctx))) { }

        protected override Alumno CreateEntity() => new()
        {
            Apellido = "Gomez",
            Nombre = "Juan",
            NroDocumento = "12345678",
            TipoDocumento = TipoDocumento.DNI,
            FechaNacimiento = "2000-01-01",
            Sexo = "M",
            NroLegajo = 1001,
            FechaIngreso = new DateTime(2020, 3, 1)
        };

        protected override void CheckEntity(Alumno alumno)
        {
            Assert.NotNull(alumno);
            Assert.Equal("Gomez", alumno.Apellido);
            Assert.Equal("Juan", alumno.Nombre);
            Assert.Equal("12345678", alumno.NroDocumento);
            Assert.Equal(TipoDocumento.DNI, alumno.TipoDocumento);
            Assert.Equal("2000-01-01", alumno.FechaNacimiento);
            Assert.Equal("M", alumno.Sexo);
            Assert.Equal(1001, alumno.NroLegajo);
            Assert.Equal(new DateTime(2020, 3, 1), alumno.FechaIngreso);
        }

        protected override Alumno Create(Alumno entity) => Service.Create(entity);
        protected override Alumno? GetById(int id) => Service.SearchById(id);
        protected override IList<Alumno> GetAll() => Service.SearchAll();
        protected override Alumno Update(Alumno entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Alumno entity) => entity.Id;
        protected override void ModifyEntity(Alumno entity)
        {
            entity.Apellido = "Sanchez";
        }
        protected override void CheckUpdatedEntity(Alumno alumno)
        {
            Assert.Equal("Sanchez", alumno.Apellido);
        }
    }
}