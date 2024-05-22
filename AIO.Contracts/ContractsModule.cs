using Autofac;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using Module = Autofac.Module;

namespace AIO.Contracts
{
    public class ContractsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HolderOfDTO>().As<IHolderOfDTO>()
                .InstancePerLifetimeScope();
        }
    }
}
