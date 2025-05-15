using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Autoridad. </summary>

public class AutoridadService : BaseService<Autoridad>
{
    public AutoridadService(AutoridadRepository repository) : base(repository)
    {
    }
}
