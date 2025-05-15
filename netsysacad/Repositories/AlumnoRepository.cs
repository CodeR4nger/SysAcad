namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Alumno. </summary>
public class AlumnoRepository : BaseRepository<Alumno>
{
    public AlumnoRepository(DatabaseContext context) : base(context)
    {
    }
}