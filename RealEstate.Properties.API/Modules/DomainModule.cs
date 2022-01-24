using RealEstate.Properties.Domain.Services;
using RealEstate.Properties.Contracts.Repository;
using RealEstate.Properties.Contracts.Services;
using RealEstate.Properties.Infrastructure.Repository;
using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Domain.Repositories;
using Autofac;

namespace RealEstate.Properties.API.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryContext<>))
                .As(typeof(IRepositoryContext<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerLifetimeScope();

            builder.RegisterType<RepositoryContext<PropertiesContext>>()
                .As<IPropertiesContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<PropertiesContext, OwnerEntity>>()
                .As<IOwnerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<PropertiesContext, PropertyEntity>>()
                .As<IPropertyRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<PropertiesContext, PropertyImageEntity>>()
                .As<IPropertyImageRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<PropertiesContext, PropertyTraceEntity>>()
                .As<IPropertyTraceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PropertiesService>()
                .As<IPropertiesService>()
                .InstancePerLifetimeScope();
        }
    }
}
