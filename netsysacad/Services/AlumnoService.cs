using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;


///<summary> Servicio para la entidad Alumno. </summary>
public class AlumnoService
{
    private readonly AlumnoRepository _repository;

    public AlumnoService(AlumnoRepository repository)
    {
        _repository = repository;
    }

    public Alumno Create(Alumno alumno) => _repository.Create(alumno);
    public Alumno SearchById(int id) => _repository.SearchById(id);
    public List<Alumno> SearchAll() => _repository.SearchAll();
    public Alumno Update(Alumno alumno) => _repository.Update(alumno);
    public bool DeleteById(int id) => _repository.DeleteById(id);
}