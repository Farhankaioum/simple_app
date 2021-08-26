using BookApp.Data;
using BookApp.Foundation.Contexts;
using BookApp.Foundation.Entities;

namespace BookApp.Foundation.Repositories
{
    public interface IPermissionRepository : IRepository<Permission, int, BookDbContext>
    {
    }
}
