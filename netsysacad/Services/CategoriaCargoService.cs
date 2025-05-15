using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad CategoriaCargo. </summary>

public class CategoriaCargoService : BaseService<CategoriaCargo>
{
    public CategoriaCargoService(CategoriaCargoRepository repository) : base(repository)
    {
    }
}
