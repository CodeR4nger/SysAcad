using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Especialidad. </summary>

public class EspecialidadService : BaseService<Especialidad>
{
    public EspecialidadService(EspecialidadRepository repository) : base(repository)
    {
    }
}
