using ASPNET.Fundamentals.DI.Autofac.Repositories;
using Autofac;

namespace ASPNET.Fundamentals.DI.Autofac.Modules
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CharacterRepository>().As<ICharacterRepository>();
        }
    }
}
