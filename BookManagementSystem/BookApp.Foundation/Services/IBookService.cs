using BookApp.Foundation.Entities;
using System;
using System.Collections.Generic;

namespace BookApp.Foundation.Services
{
    public interface IBookService
    {
        public IList<Book> GetAll();
        public IList<Book> GetAll(string userId);
        public Book GetById(Guid id, string userId);
        public Book GetById(Guid id);
        public void Add(Book book, string userId);
        public void Update(Book book, string userId);
        public void Update(Book book);
        public IList<Book> GetAllArchiveBook();
        public IList<Book> GetAllArchiveBook(string userId);
        public Book GetArchiveBookById(Guid id, string userId);
        public Book GetArchiveBookById(Guid id);
        public void Archive(Guid id, string userId);
        public void Archive(Guid id);
        public void RestoreAll();
        public void RestoreAll(string userId);
        public void RestoreById(Guid id, string userId);
        public void RestoreById(Guid id);
        public void Delete(Guid id, string userId);
        public void Delete(Guid id);
    }
}
