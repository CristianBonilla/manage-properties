using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Properties.Contracts.Repository
{
    /// <summary>
    /// Represents the repository that according to the context and entity
    /// </summary>
    /// <typeparam name="TContext">EF Context</typeparam>
    /// <typeparam name="TEntity">Context entity</typeparam>
    public interface IRepository<in TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        /// <summary>
        /// Receives the entity to put it in inserted state
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity in inserted state</returns>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Receives a range of entities to put them in inserted state
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Entities in inserted state</returns>
        IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Receives the entity to put it in updated state
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity in updated state</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Receives a range of entities to put them in updated state
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Entities in updated state</returns>
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Receives an entity to put it in deleted state
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity in deleted state</returns>
        TEntity Delete(TEntity entity);

        /// <summary>
        /// Receives a range of entities to put them in deleted state
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Entities in deleted state</returns>
        IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Find entity based on received primary keys
        /// </summary>
        /// <param name="primaryKeys">Primary keys</param>
        /// <returns>Entity found</returns>
        TEntity Find(params object[] primaryKeys);

        /// <summary>
        /// Find entity based on predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Entity found</returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Check if entity exists based on predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Existing or non-existent entity</returns>
        bool Exists(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get all entities including navigation properties
        /// </summary>
        /// <param name="includes">Included properties</param>
        /// <returns>Entities</returns>
        IEnumerable<TEntity> Get(params Expression<Func<TEntity, bool>>[] includes);

        /// <summary>
        /// Get all entities based on received filter
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Filtered entities</returns>
        IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get all entities according to the order received
        /// </summary>
        /// <param name="orderBy">Order by</param>
        /// <returns>Ordered entities</returns>
        IEnumerable<TEntity> GetByOrder(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
    }
}
