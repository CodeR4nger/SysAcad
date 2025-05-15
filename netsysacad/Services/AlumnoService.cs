using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Alumno. </summary>

public class AlumnoService : BaseService<Alumno>
{
    public AlumnoService(AlumnoRepository repository) : base(repository)
    {
    }
}
