using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Properties.Domain.Context
{
    /// <summary>
    /// Context for the properties according to the entities that were part of the database
    /// </summary>
    public partial class PropertiesContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesContext"/> class
        /// </summary>
        /// <param name="options">Context options to create the corresponding instance</param>
        public PropertiesContext(DbContextOptions<PropertiesContext> options) : base(options) { }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
