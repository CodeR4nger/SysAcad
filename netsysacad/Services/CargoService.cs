using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Cargo. </summary>

public class CargoService : BaseService<Cargo>
{
    public CargoService(CargoRepository repository) : base(repository)
    {
    }
}
