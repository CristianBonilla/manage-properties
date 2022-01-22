using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealEstate.Properties.Contracts.Repository;

namespace RealEstate.Properties.Infrastructure.Repository
{
    /// <inheritdoc cref="IRepository{TContext, TEntity}"/>
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        readonly DbSet<TEntity> entitySet;
        readonly Func<TEntity, EntityEntry<TEntity>> entityEntry;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TContext, TEntity}"/> class
        /// </summary>
        /// <param name="context">Repository context</param>
        public Repository(IRepositoryContext<TContext> context)
        {
            entitySet = context.Set<TEntity>();
            entityEntry = entity => context.Entry(entity);
        }

        /// <inheritdoc/>
        public TEntity Create(TEntity entity) => entitySet.Add(entity)?.Entity;

        /// <inheritdoc/>
        public IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities)
        {
            return Range().ToList();

            IEnumerable<TEntity> Range()
            {
                foreach (TEntity entity in entities)
                    yield return Create(entity);
            }
        }

        /// <inheritdoc/>
        public TEntity Update(TEntity entity)
        {
            var entry = entityEntry(entity);
            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);
            var updated = entitySet.Update(entity);

            return updated.Entity;
        }

        /// <inheritdoc/>
        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            return Range().ToList();

            IEnumerable<TEntity> Range()
            {
                foreach (TEntity entity in entities)
                    yield return Update(entity);
            }
        }

        /// <inheritdoc/>
        public TEntity Delete(TEntity entity)
        {
            var entry = entityEntry(entity);
            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);
            var deleted = entitySet.Remove(entity);

            return deleted.Entity;
        }

        /// <inheritdoc/>
        public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
        {
            return Range().ToList();

            IEnumerable<TEntity> Range()
            {
                foreach (TEntity entity in entities)
                    yield return Delete(entity);
            }
        }

        /// <inheritdoc/>
        public TEntity Find(params object[] primaryKeys) => entitySet.Find(primaryKeys);

        /// <inheritdoc/>
        public TEntity Find(Expression<Func<TEntity, bool>> predicate) => entitySet.FirstOrDefault(predicate);

        /// <inheritdoc/>
        public bool Exists(Expression<Func<TEntity, bool>> predicate) => entitySet.Any(predicate);

        /// <inheritdoc/>
        public IEnumerable<TEntity> Get() => entitySet.ToList();

        /// <inheritdoc/>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter) => entitySet.Where(filter).ToList();

        /// <inheritdoc/>
        public IEnumerable<TEntity> Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            var querySet = entitySet.AsQueryable();

            return orderBy(querySet).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<TEntity> Get(params Expression<Func<TEntity, bool>>[] includes)
        {
            var querySet = entitySet.AsQueryable();
            foreach (var expression in includes)
                querySet = querySet.Include(expression);

            return querySet.ToList();
        }
    }
}
