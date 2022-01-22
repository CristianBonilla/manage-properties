using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RealEstate.Properties.Contracts.Repository
{
    /// <summary>
    /// Represents the set and entry for the repositories
    /// </summary>
    /// <typeparam name="TContext">EF Context</typeparam>
    public interface IRepositoryContext<in TContext> : IDisposable where TContext : DbContext
    {
        /// <summary>
        /// Get the context set
        /// </summary>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Set</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Get the context entry
        /// </summary>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <param name="entity">Entity object</param>
        /// <returns>Entity Entry</returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Save all changes made in the context to the database
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        int Save();

        /// <summary>
        /// Save all changes made in the context to the database
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation with
        /// the number of state entries written to the database</returns>
        Task<int> SaveAsync();
    }
}
