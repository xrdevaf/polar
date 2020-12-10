using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorLocal.Data
{
    public class EFRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {           
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Take(int count)
        {
            return _dbSet.Take(count).ToList();
        }

        public IEnumerable<TEntity> Take(int count, Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).Take(count).ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity FindById(string id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Create(TEntity item)
        {
            var itemNew = _dbSet.Add(item).Entity;
            _context.SaveChanges();
            return itemNew;
        }
        public TEntity Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Attach(item);
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
