using netsysacad.Models;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Tests.Utils;

namespace netsysacad.Tests.Models
{
    public class DepartamentoTests : EntityTestBase<Departamento, DepartamentoService>
    {
        public DepartamentoTests()
            : base(ctx => new DepartamentoService(new DepartamentoRepository(ctx))) { }

        protected override Departamento CreateEntity() => new()
        {
            Nombre = "Departamento de Sistemas", 
        };

        protected override void CheckEntity(Departamento departamento)
        {
            Assert.NotNull(departamento);
            Assert.Equal("Departamento de Sistemas",departamento.Nombre);
        }

        protected override Departamento Create(Departamento entity) => Service.Create(entity);
        protected override Departamento? GetById(int id) => Service.SearchById(id);
        protected override IList<Departamento> GetAll() => Service.SearchAll();
        protected override Departamento Update(Departamento entity) => Service.Update(entity);
        protected override bool Delete(int id) => Service.DeleteById(id);
        protected override int GetId(Departamento entity) => entity.Id;
        protected override void ModifyEntity(Departamento entity)
        {
            entity.Nombre = "Departamento de Electromecanica";
        }
        protected override void CheckUpdatedEntity(Departamento entity)
        {
            Assert.Equal("Departamento de Electromecanica", entity.Nombre);
        }
    }
}