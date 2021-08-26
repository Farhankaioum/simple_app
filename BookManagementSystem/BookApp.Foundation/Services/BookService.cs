using BookApp.Foundation.Entities;
using BookApp.Foundation.Exceptions;
using BookApp.Foundation.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookApp.Foundation.Services
{
    public class BookService : IBookService
    {
        private readonly IBookUnitOfWork _bookUnitOfWork;

        public BookService(IBookUnitOfWork bookUnitOfWork)
        {
            _bookUnitOfWork = bookUnitOfWork;
        }

        public void Add(Book book, string userId)
        {
            book.UserId = userId;
            _bookUnitOfWork.BookRepository.Add(book);
            _bookUnitOfWork.Save();
        }

        public IList<Book> GetAll()
        {
            return _bookUnitOfWork.BookRepository.GetAll();
        }

        public IList<Book> GetAll(string userId)
        {
            return _bookUnitOfWork.BookRepository.Get(x => x.UserId == userId);
        }

        public Book GetById(Guid id, string userId)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id && x.UserId == userId)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            return existingBook;
        }

        public Book GetById(Guid id)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            return existingBook;
        }

        public void Update(Book book, string userId)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == book.Id && x.UserId == userId)
               .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            existingBook.Description = book.Description;
            existingBook.ShortDescription = book.ShortDescription;
            existingBook.IsArchived = book.IsArchived;

            _bookUnitOfWork.BookRepository.Edit(existingBook);
            _bookUnitOfWork.Save();
        }

        public void Update(Book book)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == book.Id)
               .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.ShortDescription = book.ShortDescription;
            existingBook.IsArchived = book.IsArchived;

            _bookUnitOfWork.BookRepository.Edit(existingBook);
            _bookUnitOfWork.Save();
        }

        public IList<Book> GetAllArchiveBook()
        {
            return _bookUnitOfWork.BookRepository.Get(x => x.IsArchived == true);
        }

        public IList<Book> GetAllArchiveBook(string userId)
        {
            return _bookUnitOfWork.BookRepository.Get(x => x.UserId == userId && x.IsArchived == true);
        }

        public Book GetArchiveBookById(Guid id, string userId)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id && x.UserId == userId && x.IsArchived == true)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            return existingBook;
        }

        public Book GetArchiveBookById(Guid id)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id && x.IsArchived == true)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            return existingBook;
        }

        public void Archive(Guid id)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            existingBook.IsArchived = true;
            _bookUnitOfWork.BookRepository.Edit(existingBook);
            _bookUnitOfWork.Save();
        }

        public void Archive(Guid id, string userId)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id ==id && x.UserId == userId)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            existingBook.IsArchived = true;
            _bookUnitOfWork.BookRepository.Edit(existingBook);
            _bookUnitOfWork.Save();
        }

        public void Delete(Guid id, string userId)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id && x.UserId == userId)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            _bookUnitOfWork.BookRepository.Remove(existingBook);
            _bookUnitOfWork.Save();
        }

        public void Delete(Guid id)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            _bookUnitOfWork.BookRepository.Remove(existingBook);
            _bookUnitOfWork.Save();
        }

        public void RestoreAll()
        {
            var existingBooks = _bookUnitOfWork.BookRepository.Get(x => x.IsArchived == true);
            foreach (var book in existingBooks)
            {
                book.IsArchived = false;
                _bookUnitOfWork.BookRepository.Edit(book);
            }

            _bookUnitOfWork.Save();
        }

        public void RestoreAll(string userId)
        {
            var existingBooks = _bookUnitOfWork.BookRepository.Get(x => x.UserId == userId && x.IsArchived == true);
            foreach (var book in existingBooks) 
            {
                book.IsArchived = false;
                _bookUnitOfWork.BookRepository.Edit(book);
            }
            
            _bookUnitOfWork.Save();
        }

        public void RestoreById(Guid id, string userId)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id && x.UserId == userId)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            existingBook.IsArchived = false;
            _bookUnitOfWork.BookRepository.Edit(existingBook);
            _bookUnitOfWork.Save();
        }

        public void RestoreById(Guid id)
        {
            var existingBook = _bookUnitOfWork.BookRepository.Get(x => x.Id == id)
                .FirstOrDefault();

            if (existingBook == null)
                throw new NotFoundException("Book not found");

            existingBook.IsArchived = false;
            _bookUnitOfWork.BookRepository.Edit(existingBook);
            _bookUnitOfWork.Save();
        }
    }
}
