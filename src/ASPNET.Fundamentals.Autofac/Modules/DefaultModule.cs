using ASPNET.Fundamentals.Autofac.Repositories;
using Autofac;

namespace ASPNET.Fundamentals.Autofac.Modules
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CharacterRepository>().As<ICharacterRepository>();
        }
    }
}
