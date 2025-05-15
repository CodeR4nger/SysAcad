using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;

public class AreaService : BaseService<Area>
{
    public AreaService(AreaRepository repository) : base(repository)
    {
    }
}
