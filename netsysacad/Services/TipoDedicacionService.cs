using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad TipoDedicacion. </summary>

public class TipoDedicacionService : BaseService<TipoDedicacion>
{
    public TipoDedicacionService(TipoDedicacionRepository repository) : base(repository)
    {
    }
}
