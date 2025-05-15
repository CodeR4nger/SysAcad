using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Grupo. </summary>

public class GrupoService : BaseService<Grupo>
{
    public GrupoService(GrupoRepository repository) : base(repository)
    {
    }
}
