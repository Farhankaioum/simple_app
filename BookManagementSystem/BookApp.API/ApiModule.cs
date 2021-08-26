using Autofac;
using BookApp.API.Helpers;

namespace BookApp.API
{
    public class ApiModule : Module
    {
        public ApiModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PermissionHelper>().AsSelf()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
