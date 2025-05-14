namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Alumno. </summary>
public class AlumnoRepository
{
    private readonly DatabaseContext _context;

    public AlumnoRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Alumno Create(Alumno alumno)
    {
        _context.Add(alumno);
        _context.SaveChanges();
        return alumno;
    }

    public Alumno SearchById(int id)
    {
        return _context.Alumnos.FirstOrDefault(a => a.Id == id);
    }

    public List<Alumno> SearchAll()
    {
        return _context.Alumnos.ToList();
    }

    public Alumno Update(Alumno alumno)
    {
        var existingAlumno = _context.Alumnos.FirstOrDefault(a => a.Id == alumno.Id);
        if (existingAlumno == null) return null;

        existingAlumno.Apellido = alumno.Apellido;
        existingAlumno.Nombre = alumno.Nombre;
        existingAlumno.NroDocumento = alumno.NroDocumento;
        existingAlumno.TipoDocumento = alumno.TipoDocumento;
        existingAlumno.FechaNacimiento = alumno.FechaNacimiento;
        existingAlumno.Sexo = alumno.Sexo;
        existingAlumno.NroLegajo = alumno.NroLegajo;
        existingAlumno.FechaIngreso = alumno.FechaIngreso;

        _context.SaveChanges();
        return existingAlumno;
    }

    public bool DeleteById(int id)
    {
        var alumno = _context.Alumnos.FirstOrDefault(a => a.Id == id);
        if (alumno == null) return false;

        _context.Alumnos.Remove(alumno);
        _context.SaveChanges();
        return true;
    }
}