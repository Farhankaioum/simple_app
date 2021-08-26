using BookApp.Data;
using BookApp.Foundation.Repositories;

namespace BookApp.Foundation.UnitOfWorks
{
    public interface IBookUnitOfWork : IUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }
        public IPermissionRepository PermissionRepository { get; set; }
    }
}
