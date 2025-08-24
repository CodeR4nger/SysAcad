using netsysacad.Data;
using Microsoft.EntityFrameworkCore;
using netsysacad.Mapping;
using Microsoft.AspNetCore.Mvc;

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

    public IEnumerable<T> ApplyFilters(IQueryable<T> source, IEnumerable<ApiFilter> filters)
    {
        var properties = typeof(T).GetProperties().ToDictionary(p => p.Name, p => p);

        return source.AsEnumerable().Where(item =>
        {
            foreach (var filter in filters)
            {
                if (!properties.TryGetValue(filter.Field, out var property))
                    return false;

                var propValue = property.GetValue(item)?.ToString();
                if (propValue == null)
                    return false;

                var passesFilter = filter.Operation switch
                {
                    "==" => propValue.Equals(filter.Value, StringComparison.OrdinalIgnoreCase),
                    "!=" => !propValue.Equals(filter.Value, StringComparison.OrdinalIgnoreCase),
                    "contains" => propValue.Contains(filter.Value, StringComparison.OrdinalIgnoreCase),
                    _ => false
                };

                if (!passesFilter)
                    return false;
            }

            return true;
        });
    }



    public virtual List<T> SearchPage(int? page, int? elementsPerPage, List<ApiFilter>? filters)
    {
        int pageNumber = page.GetValueOrDefault(1);
        int pageSize = elementsPerPage.GetValueOrDefault(10);

        var query = _dbSet.AsQueryable();

        if (filters != null && filters.Count != 0)
        {
            var filtered = ApplyFilters(query, filters);
            return filtered
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        return query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
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
