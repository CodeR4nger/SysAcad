namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Autoridad. </summary>
public class AutoridadRepository : BaseRepository<Autoridad>
{
    public AutoridadRepository(DatabaseContext context) : base(context)
    {
    }
}