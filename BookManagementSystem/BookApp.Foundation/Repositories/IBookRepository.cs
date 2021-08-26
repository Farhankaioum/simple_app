using BookApp.Data;
using BookApp.Foundation.Contexts;
using BookApp.Foundation.Entities;
using System;

namespace BookApp.Foundation.Repositories
{
    public interface IBookRepository : IRepository<Book, Guid, BookDbContext>
    {
    }
}
