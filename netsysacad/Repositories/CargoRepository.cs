namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Cargo. </summary>
public class CargoRepository
{
    private readonly DatabaseContext _context;

    public CargoRepository(DatabaseContext context)
    {
        _context = context;
    }
    public Cargo Create(Cargo cargo)
    {
        _context.Add(cargo);
        _context.SaveChanges();
        return cargo;
    }

    public Cargo SearchById(int id)
    {
        return _context.Cargos.FirstOrDefault(a => a.Id == id);
    }

    public List<Cargo> SearchAll()
    {
        return _context.Cargos.ToList();
    }

    public Cargo Update(Cargo cargo)
    {
        var existingCargo = _context.Cargos.FirstOrDefault(a => a.Id == cargo.Id);
        if (existingCargo == null) return null;

        existingCargo.Nombre = cargo.Nombre;

        _context.SaveChanges();
        return existingCargo;
    }

    public bool DeleteById(int id)
    {
        var cargo = _context.Cargos.FirstOrDefault(a => a.Id == id);
        if (cargo == null) return false;

        _context.Cargos.Remove(cargo);
        _context.SaveChanges();
        return true;
    }
}