using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Materia. </summary>

public class MateriaService : BaseService<Materia>
{
    public MateriaService(MateriaRepository repository) : base(repository)
    {
    }
}
