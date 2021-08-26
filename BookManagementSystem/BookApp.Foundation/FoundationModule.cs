using Autofac;
using BookApp.Foundation.Contexts;

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

            base.Load(builder);
        }
    }
}
