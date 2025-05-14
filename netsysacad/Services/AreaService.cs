using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;

public class AreaService
{
    private readonly AreaRepository _repository;

    public AreaService(AreaRepository repository)
    {
        _repository = repository;
    }

    public Area Create(Area area) => _repository.Create(area);
    public Area SearchById(int id) => _repository.SearchById(id);
    public List<Area> SearchAll() => _repository.SearchAll();
    public Area Update(Area area) => _repository.Update(area);
    public bool DeleteById(int id) => _repository.DeleteById(id);
}