namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad TipoDedicacion. </summary>
public class TipoDedicacionRepository
{
    private readonly DatabaseContext _context;

    public TipoDedicacionRepository(DatabaseContext context)
    {
        _context = context;
    }
    public TipoDedicacion Create(TipoDedicacion tipoDedicacion)
    {
        _context.Add(tipoDedicacion);
        _context.SaveChanges();
        return tipoDedicacion;
    }

    public TipoDedicacion SearchById(int id)
    {
        return _context.TiposDedicacion.FirstOrDefault(a => a.Id == id);
    }

    public List<TipoDedicacion> SearchAll()
    {
        return _context.TiposDedicacion.ToList();
    }

    public TipoDedicacion Update(TipoDedicacion tipoDedicacion)
    {
        var existingTipoDedicacion = _context.TiposDedicacion.FirstOrDefault(a => a.Id == tipoDedicacion.Id);
        if (existingTipoDedicacion == null) return null;

        existingTipoDedicacion.Nombre = tipoDedicacion.Nombre;

        _context.SaveChanges();
        return existingTipoDedicacion;
    }

    public bool DeleteById(int id)
    {
        var tipoDedicacion = _context.TiposDedicacion.FirstOrDefault(a => a.Id == id);
        if (tipoDedicacion == null) return false;

        _context.TiposDedicacion.Remove(tipoDedicacion);
        _context.SaveChanges();
        return true;
    }
}