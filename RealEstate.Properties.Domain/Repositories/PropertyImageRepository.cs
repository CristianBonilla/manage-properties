using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Infrastructure.Repository;

namespace RealEstate.Properties.Domain.Repositories
{
    /// <inheritdoc/>
    public class PropertyImageRepository : Repository<PropertiesContext, PropertyImageEntity>, IPropertyImageRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyImageRepository"/> class
        /// </summary>
        /// <param name="context">Properties repository context</param>
        public PropertyImageRepository(IPropertiesRepositoryContext context) : base(context) { }
    }
}
