using netsysacad.Models;
using netsysacad.Repositories;

namespace netsysacad.Services;

public class DepartamentoService : BaseService<Departamento>
{
    public DepartamentoService(DepartamentoRepository repository) : base(repository)
    {
    }
}
