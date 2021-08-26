using Autofac;
using BookApp.Foundation.Contexts;
using BookApp.Foundation.Repositories;
using BookApp.Foundation.Services;
using BookApp.Foundation.UnitOfWorks;

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

            builder.RegisterType<BookUnitOfWork>().As<IBookUnitOfWork>()
               .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>().As<IBookRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<PermissionRepository>().As<IPermissionRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<PermissionService>().As<IPermissionService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<BookService>().As<IBookService>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
