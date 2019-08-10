using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MangaStore.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.DataAccess.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbContext;

        protected Repository(DbContext dbContext)
        {
            DbContext = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbContext.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Where(expression);
        }

        public TEntity Get(int id)
        {
            return DbContext.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.ToList();
        }

        public void Remove(TEntity entity)
        {
            DbContext.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbContext.RemoveRange(entities);
        }
    }
}
