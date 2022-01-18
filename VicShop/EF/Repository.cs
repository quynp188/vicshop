using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace VicShop.EF;

public class Repository<T, K> : IRepository<T, K> where T : class
{
    private readonly VicShopDbContext vicShopDbContext;
    public Repository(VicShopDbContext msShopDbContext)
    {
        this.vicShopDbContext = msShopDbContext;
    }
    public void Add(T entity)
    {
        vicShopDbContext.Add(entity);
    }

    public IQueryable<T> FindAll(params Expression<Func<T, object>>[]? includeProperties)
    {
        IQueryable<T> items = this.vicShopDbContext.Set<T>();
        if (includeProperties != null)
        {
            foreach (var property in includeProperties)
            {
                items = items.Include(property);
            }
        }
        return items;
    }

    public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includeProperties)
    {
        IQueryable<T> items = this.vicShopDbContext.Set<T>();
        if (includeProperties != null)
        {
            foreach (var property in includeProperties)
            {
                items = items.Include(property);
            }
        }
        return items.Where(predicate);
    }

    public T FindById(K id) => this.vicShopDbContext.Set<T>().Find(id);

    public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includeProperties) => FindAll(includeProperties).SingleOrDefault(predicate);

    public void Remove(T entity)
    {
        this.vicShopDbContext.Set<T>().Remove(entity);
    }

    public void Remove(K id)
    {
        var entity = FindById(id);
        Remove(entity);
    }

    public void RemoveMultiple(List<T> entities)
    {
        this.vicShopDbContext.Set<T>().RemoveRange(entities);
    }

    public void Update(T entity)
    {
        this.vicShopDbContext.Set<T>().Update(entity);
    }
    public void Dispose()
    {
        this.vicShopDbContext.Dispose();
    }
}