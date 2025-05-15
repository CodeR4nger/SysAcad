using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad TipoEspecialidad. </summary>

public class TipoEspecialidadService : BaseService<TipoEspecialidad>
{
    public TipoEspecialidadService(TipoEspecialidadRepository repository) : base(repository)
    {
    }
}
