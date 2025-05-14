using netsysacad.Models;
using netsysacad.Repositories;
namespace netsysacad.Services;

public class TipoDedicacionService
{
    private readonly TipoDedicacionRepository _repository;

    public TipoDedicacionService(TipoDedicacionRepository repository)
    {
        _repository = repository;
    }

    public TipoDedicacion Create(TipoDedicacion tipoDedicacion) => _repository.Create(tipoDedicacion);
    public TipoDedicacion SearchById(int id) => _repository.SearchById(id);
    public List<TipoDedicacion> SearchAll() => _repository.SearchAll();
    public TipoDedicacion Update(TipoDedicacion tipoDedicacion) => _repository.Update(tipoDedicacion);
    public bool DeleteById(int id) => _repository.DeleteById(id);
}