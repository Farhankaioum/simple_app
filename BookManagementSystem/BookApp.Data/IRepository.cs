using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookApp.Data
{
    public interface IRepository<TEntity, TKey, TContext>
        where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);
        void Remove(TKey id);
        void Remove(TEntity entityToDelete);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Edit(TEntity entityToUpdate);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetAll();
        TEntity GetById(TKey id);
    }
}
