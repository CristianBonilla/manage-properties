using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Infrastructure.Repository;

namespace RealEstate.Properties.Domain.Repositories
{
    /// <inheritdoc/>
    public class PropertyRepository : Repository<PropertiesContext, PropertyEntity>, IPropertyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyRepository"/> class
        /// </summary>
        /// <param name="context">Properties repository context</param>
        public PropertyRepository(IPropertiesRepositoryContext context) : base(context) { }
    }
}
