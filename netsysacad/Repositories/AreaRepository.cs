namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Area. </summary>
public class AreaRepository : BaseRepository<Area>
{
    public AreaRepository(DatabaseContext context) : base(context)
    {
    }
}