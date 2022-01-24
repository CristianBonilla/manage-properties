using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Contracts.Repository;

namespace RealEstate.Properties.Domain.Repositories
{
    /// <inheritdoc/>
    public interface IOwnerRepository : IRepository<PropertiesContext, OwnerEntity> { }
}
