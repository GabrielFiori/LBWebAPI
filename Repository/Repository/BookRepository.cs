using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Repository.Interface;
using Domain.Interface;

namespace Repository.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookMemoryCache _bookMemoryCache;

        public BookRepository(IBookMemoryCache bookMemoryCache)
        {
            _bookMemoryCache = bookMemoryCache;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookMemoryCache.GetAll();
        }

        public Book GetByName(string name)
        {
            return _bookMemoryCache.GetByName(name);
        }

        public Book GetById(int id)
        {
            return _bookMemoryCache.GetById(id);
        }

        public int GetNewId()
        {
            return _bookMemoryCache.GetNewId();
        }

        public void Add(Book addBook)
        {
            _bookMemoryCache.Add(addBook);
        }

        public void Remove(int id)
        {
            _bookMemoryCache.Remove(id);
        }

        public void Update(Book book)
        {
            _bookMemoryCache.Update(book);
        }

        public void Borrow(int id)
        {
            _bookMemoryCache.Borrow(id);
        }

        public IEnumerable<Book> GetAllBorrowed()
        {
            return _bookMemoryCache.GetAllBorrowed();
        }

        public Book GetBorrowedById(int id)
        {
            return _bookMemoryCache.GetBorrowedById(id);
        }

        public void ReturnBook(int id)
        {
            _bookMemoryCache.ReturnBook(id);
        }
    }
}
