namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Plan. </summary>
public class PlanRepository : BaseRepository<Plan>
{
    public PlanRepository(DatabaseContext context) : base(context)
    {
    }
}