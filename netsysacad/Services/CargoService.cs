using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;

public class CargoService
{
    private readonly CargoRepository _repository;

    public CargoService(CargoRepository repository)
    {
        _repository = repository;
    }

    public Cargo Create(Cargo cargo) => _repository.Create(cargo);
    public Cargo SearchById(int id) => _repository.SearchById(id);
    public List<Cargo> SearchAll() => _repository.SearchAll();
    public Cargo Update(Cargo cargo) => _repository.Update(cargo);
    public bool DeleteById(int id) => _repository.DeleteById(id);
}