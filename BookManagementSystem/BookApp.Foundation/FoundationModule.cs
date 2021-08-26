using Autofac;
using BookApp.Foundation.Contexts;
using BookApp.Foundation.Services;

namespace BookApp.Foundation
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionStringName, string migrationAssemblyName)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>()
              .WithParameter("connectionString", _connectionString)
              .WithParameter("migrationAssemblyName", _migrationAssemblyName)
              .InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
