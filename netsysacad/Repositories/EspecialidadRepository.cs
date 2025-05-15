namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Especialidad. </summary>
public class EspecialidadRepository : BaseRepository<Especialidad>
{
    public EspecialidadRepository(DatabaseContext context) : base(context)
    {
    }
}