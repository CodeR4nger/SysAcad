using netsysacad.Repositories;
namespace netsysacad.Services;
public class BaseService<T> where T : class
{
    protected readonly BaseRepository<T> _repository;

    public BaseService(BaseRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual T Create(T entity) => _repository.Create(entity);
    public virtual T? SearchById(int id) => _repository.SearchById(id);
    public virtual List<T> SearchAll() => _repository.SearchAll();
    public virtual T Update(T entity) => _repository.Update(entity);
    public virtual bool DeleteById(int id) => _repository.DeleteById(id);
}
