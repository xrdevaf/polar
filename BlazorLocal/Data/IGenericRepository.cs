using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLocal.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Take(int count);
        IEnumerable<TEntity> Take(int count, Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        TEntity Update(TEntity item);
    }
}
