namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Orientacion. </summary>
public class OrientacionRepository : BaseRepository<Orientacion>
{
    public OrientacionRepository(DatabaseContext context) : base(context)
    {
    }
}