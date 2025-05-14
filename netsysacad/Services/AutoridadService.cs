using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;

public class AutoridadService
{
    private readonly AutoridadRepository _repository;

    public AutoridadService(AutoridadRepository repository)
    {
        _repository = repository;
    }

    public Autoridad Create(Autoridad autoridad) => _repository.Create(autoridad);
    public Autoridad SearchById(int id) => _repository.SearchById(id);
    public List<Autoridad> SearchAll() => _repository.SearchAll();
    public Autoridad Update(Autoridad autoridad) => _repository.Update(autoridad);
    public bool DeleteById(int id) => _repository.DeleteById(id);
}