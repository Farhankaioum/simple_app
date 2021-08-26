using BookApp.Data;
using BookApp.Foundation.Contexts;
using BookApp.Foundation.Entities;
using System;

namespace BookApp.Foundation.Repositories
{
    public class BookRepository : Repository<Book, Guid, BookDbContext>, IBookRepository
    {
        public BookRepository(BookDbContext bookDbContext)
            : base(bookDbContext)
        {

        }
    }
}
