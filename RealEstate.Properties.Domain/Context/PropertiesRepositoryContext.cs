using RealEstate.Properties.Infrastructure.Repository;

namespace RealEstate.Properties.Domain.Context
{
    /// <inheritdoc/>
    public class PropertiesRepositoryContext : RepositoryContext<PropertiesContext>, IPropertiesRepositoryContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesRepositoryContext"/> class
        /// </summary>
        /// <param name="context"></param>
        public PropertiesRepositoryContext(PropertiesContext context) : base(context) { }
    }
}
