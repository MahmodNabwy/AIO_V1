using Autofac;
using AIO.Core.IServices.Custom;
using AIO.Infrastructure.Services.Custom;
using Module = Autofac.Module;

namespace AIO.Infrastructure
{
    public class InfrastructureModule : Module
    {
        // IOC Container Methods
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();

        }
    }
}
