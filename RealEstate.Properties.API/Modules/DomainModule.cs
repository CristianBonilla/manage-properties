using Autofac;
using RealEstate.Properties.Domain.Services;
using RealEstate.Properties.Contracts.Repository;
using RealEstate.Properties.Contracts.Services;
using RealEstate.Properties.Infrastructure.Repository;
using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Repositories;

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

            builder.RegisterType<PropertiesRepositoryContext>()
                .As<IPropertiesRepositoryContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OwnerRepository>()
                .As<IOwnerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PropertyRepository>()
                .As<IPropertyRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PropertyImageRepository>()
                .As<IPropertyImageRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PropertyTraceRepository>()
                .As<IPropertyTraceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PropertiesService>()
                .As<IPropertiesService>()
                .InstancePerLifetimeScope();
        }
    }
}
