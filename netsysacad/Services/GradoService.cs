using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Grado. </summary>

public class GradoService : BaseService<Grado>
{
    public GradoService(GradoRepository repository) : base(repository)
    {
    }
}
