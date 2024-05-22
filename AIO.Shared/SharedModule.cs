using Autofac;
using AIO.Shared.Helpers;
using AIO.Shared.Interfaces;
using Module = Autofac.Module;

namespace AIO.Shared
{
    public class SharedModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Culture>().As<ICulture>()
                .InstancePerLifetimeScope();
        }
    }
}
