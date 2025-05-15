using netsysacad.Data;
using netsysacad.Models;

namespace netsysacad.Repositories;

public class DepartamentoRepository : BaseRepository<Departamento>
{
    public DepartamentoRepository(DatabaseContext context) : base(context)
    {
    }
}
