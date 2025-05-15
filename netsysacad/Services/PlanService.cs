using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Plan. </summary>

public class PlanService : BaseService<Plan>
{
    public PlanService(PlanRepository repository) : base(repository)
    {
    }
}
