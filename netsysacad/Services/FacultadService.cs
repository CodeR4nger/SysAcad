using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Facultad. </summary>

public class FacultadService : BaseService<Facultad>
{
    public FacultadService(FacultadRepository repository) : base(repository)
    {
    }
}
