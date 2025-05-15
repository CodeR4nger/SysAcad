namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Universidad. </summary>
public class UniversidadRepository : BaseRepository<Universidad>
{
    public UniversidadRepository(DatabaseContext context) : base(context)
    {
    }
}