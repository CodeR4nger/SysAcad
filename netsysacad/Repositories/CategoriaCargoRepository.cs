namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad CategoriaCargo. </summary>
public class CategoriaCargoRepository : BaseRepository<CategoriaCargo>
{
    public CategoriaCargoRepository(DatabaseContext context) : base(context)
    {
    }
}