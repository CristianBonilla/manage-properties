using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Infrastructure.Repository;

namespace RealEstate.Properties.Domain.Repositories
{
    /// <inheritdoc/>
    public class PropertyTraceRepository : Repository<PropertiesContext, PropertyTraceEntity>, IPropertyTraceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyTraceRepository"/> class
        /// </summary>
        /// <param name="context">Properties repository context</param>
        public PropertyTraceRepository(IPropertiesRepositoryContext context) : base(context) { }
    }
}
