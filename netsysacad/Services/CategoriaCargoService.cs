using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;

public class CategoriaCargoService
{
    private readonly CategoriaCargoRepository _repository;

    public CategoriaCargoService(CategoriaCargoRepository repository)
    {
        _repository = repository;
    }

    public CategoriaCargo Create(CategoriaCargo categoriaCargo) => _repository.Create(categoriaCargo);
    public CategoriaCargo SearchById(int id) => _repository.SearchById(id);
    public List<CategoriaCargo> SearchAll() => _repository.SearchAll();
    public CategoriaCargo Update(CategoriaCargo categoriaCargo) => _repository.Update(categoriaCargo);
    public bool DeleteById(int id) => _repository.DeleteById(id);
}