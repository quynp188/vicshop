﻿using System.Linq.Expressions;

namespace VicShop.EF;

public interface IRepository<T,K> where T:class
{
    T FindById(K id);

    T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includeProperties);

    IQueryable<T> FindAll(params Expression<Func<T, object>>[]? includeProperties);

    IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includeProperties);

    void Add(T entity);

    void Update(T entity);

    void Remove(T entity);

    void Remove(K id);

    void RemoveMultiple(List<T> entities);
}