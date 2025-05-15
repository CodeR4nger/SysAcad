namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad TipoEspecialidad. </summary>
public class TipoEspecialidadRepository : BaseRepository<TipoEspecialidad>
{
    public TipoEspecialidadRepository(DatabaseContext context) : base(context)
    {
    }
}