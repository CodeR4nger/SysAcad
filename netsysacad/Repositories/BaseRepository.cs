using netsysacad.Data;
using Microsoft.EntityFrameworkCore;

namespace netsysacad.Repositories;

public abstract class BaseRepository<T> where T : class
{
    protected readonly DatabaseContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual T Create(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual T? SearchById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual List<T> SearchAll()
    {
        return _dbSet.ToList();
    }

    public virtual List<T> SearchPage(int page, int elementsPerPage)
    {
        return _dbSet.Skip((page - 1)*elementsPerPage).Take(elementsPerPage).ToList();
    }
    
    public virtual T Update(T entity)
    {
        var entityId = _context.Entry(entity).Property("Id").CurrentValue;

        var trackedEntity = _context.ChangeTracker.Entries<T>()
            .FirstOrDefault(e =>
                e.Entity != null &&
                _context.Entry(e.Entity).Property("Id").CurrentValue is object trackedId &&
                trackedId.Equals(entityId)
            );

        if (trackedEntity != null)
        {
            trackedEntity.State = EntityState.Detached;
        }

        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public virtual bool DeleteById(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        _context.SaveChanges();
        return true;
    }
}
