using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Infrastructure.Repository;

namespace RealEstate.Properties.Domain.Repositories
{
    /// <inheritdoc/>
    public class OwnerRepository : Repository<PropertiesContext, OwnerEntity>, IOwnerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerRepository"/> class
        /// </summary>
        /// <param name="context">Properties repository context</param>
        public OwnerRepository(IPropertiesRepositoryContext context) : base(context) { }
    }
}
