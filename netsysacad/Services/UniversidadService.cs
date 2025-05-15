using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Universidad. </summary>

public class UniversidadService : BaseService<Universidad>
{
    public UniversidadService(UniversidadRepository repository) : base(repository)
    {
    }
}
