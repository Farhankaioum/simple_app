using BookApp.Data;
using BookApp.Foundation.Contexts;
using BookApp.Foundation.Entities;

namespace BookApp.Foundation.Repositories
{
    public class PermissionRepository : Repository<Permission, int, BookDbContext>, IPermissionRepository
    {
        public PermissionRepository(BookDbContext bookDbContext)
            : base(bookDbContext)
        {

        }
    }
}
