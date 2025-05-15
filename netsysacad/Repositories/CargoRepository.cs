namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Cargo. </summary>
public class CargoRepository : BaseRepository<Cargo>
{
    public CargoRepository(DatabaseContext context) : base(context)
    {
    }
}