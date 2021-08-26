using BookApp.Data;
using BookApp.Foundation.Contexts;
using BookApp.Foundation.Repositories;

namespace BookApp.Foundation.UnitOfWorks
{
    public class BookUnitOfWork : UnitOfWork, IBookUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }
        public IPermissionRepository PermissionRepository { get; set; }

        public BookUnitOfWork(BookDbContext bookDbContext,
                            IBookRepository bookRepository,
                            IPermissionRepository permissionRepository)
            : base(bookDbContext)
        {
            BookRepository = bookRepository;
            PermissionRepository = permissionRepository;
        }
    }
}
