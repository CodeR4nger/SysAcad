using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Orientacion. </summary>

public class OrientacionService : BaseService<Orientacion>
{
    public OrientacionService(OrientacionRepository repository) : base(repository)
    {
    }
}
