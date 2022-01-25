using RealEstate.Properties.Domain.Services;
using RealEstate.Properties.Contracts.Repository;
using RealEstate.Properties.Contracts.Services;
using RealEstate.Properties.Infrastructure.Repository;
using Autofac;

namespace RealEstate.Properties.API.Modules
{
    /// <summary>
    /// Provide necessary injections for the domain, during runtime
    /// </summary>
    public class DomainModule : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryContext<>))
                .As(typeof(IRepositoryContext<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerLifetimeScope();

            builder.RegisterType<PropertiesService>()
                .As<IPropertiesService>()
                .InstancePerLifetimeScope();
        }
    }
}
