namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Area. </summary>
public class AreaRepository
{
    private readonly DatabaseContext _context;

    public AreaRepository(DatabaseContext context)
    {
        _context = context;
    }
    public Area Create(Area area)
    {
        _context.Add(area);
        _context.SaveChanges();
        return area;
    }

    public Area SearchById(int id)
    {
        return _context.Areas.FirstOrDefault(a => a.Id == id);
    }

    public List<Area> SearchAll()
    {
        return _context.Areas.ToList();
    }

    public Area Update(Area area)
    {
        var existingArea = _context.Areas.FirstOrDefault(a => a.Id == area.Id);
        if (existingArea == null) return null;

        existingArea.Nombre = area.Nombre;

        _context.SaveChanges();
        return existingArea;
    }

    public bool DeleteById(int id)
    {
        var area = _context.Areas.FirstOrDefault(a => a.Id == id);
        if (area == null) return false;

        _context.Areas.Remove(area);
        _context.SaveChanges();
        return true;
    }
}