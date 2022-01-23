using Autofac;
using RealEstate.Properties.Contracts.Repository;
using RealEstate.Properties.Infrastructure.Repository;

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
        }
    }
}
