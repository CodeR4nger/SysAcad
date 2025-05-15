namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Grupo. </summary>
public class GrupoRepository : BaseRepository<Grupo>
{
    public GrupoRepository(DatabaseContext context) : base(context)
    {
    }
}