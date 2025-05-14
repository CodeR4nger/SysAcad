namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad CategoriaCargo. </summary>
public class CategoriaCargoRepository
{
    private readonly DatabaseContext _context;

    public CategoriaCargoRepository(DatabaseContext context)
    {
        _context = context;
    }
    public CategoriaCargo Create(CategoriaCargo categoriaCargo)
    {
        _context.Add(categoriaCargo);
        _context.SaveChanges();
        return categoriaCargo;
    }

    public CategoriaCargo SearchById(int id)
    {
        return _context.CategoriasCargo.FirstOrDefault(a => a.Id == id);
    }

    public List<CategoriaCargo> SearchAll()
    {
        return _context.CategoriasCargo.ToList();
    }

    public CategoriaCargo Update(CategoriaCargo categoriaCargo)
    {
        var existingCategoriaCargo = _context.CategoriasCargo.FirstOrDefault(a => a.Id == categoriaCargo.Id);
        if (existingCategoriaCargo == null) return null;

        existingCategoriaCargo.Nombre = categoriaCargo.Nombre;

        _context.SaveChanges();
        return existingCategoriaCargo;
    }

    public bool DeleteById(int id)
    {
        var categoriaCargo = _context.CategoriasCargo.FirstOrDefault(a => a.Id == id);
        if (categoriaCargo == null) return false;

        _context.CategoriasCargo.Remove(categoriaCargo);
        _context.SaveChanges();
        return true;
    }
}