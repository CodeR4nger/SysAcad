namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Autoridad. </summary>
public class AutoridadRepository
{
    private readonly DatabaseContext _context;

    public AutoridadRepository(DatabaseContext context)
    {
        _context = context;
    }
    public Autoridad Create(Autoridad autoridad)
    {
        _context.Add(autoridad);
        _context.SaveChanges();
        return autoridad;
    }

    public Autoridad SearchById(int id)
    {
        return _context.Autoridades.FirstOrDefault(a => a.Id == id);
    }

    public List<Autoridad> SearchAll()
    {
        return _context.Autoridades.ToList();
    }

    public Autoridad Update(Autoridad autoridad)
    {
        var existingAutoridad = _context.Autoridades.FirstOrDefault(a => a.Id == autoridad.Id);
        if (existingAutoridad == null) return null;

        existingAutoridad.Nombre = autoridad.Nombre;

        _context.SaveChanges();
        return existingAutoridad;
    }

    public bool DeleteById(int id)
    {
        var autoridad = _context.Autoridades.FirstOrDefault(a => a.Id == id);
        if (autoridad == null) return false;

        _context.Autoridades.Remove(autoridad);
        _context.SaveChanges();
        return true;
    }
}