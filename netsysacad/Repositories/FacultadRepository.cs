namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Facultad. </summary>
public class FacultadRepository : BaseRepository<Facultad>
{
    public FacultadRepository(DatabaseContext context) : base(context)
    {
    }
}