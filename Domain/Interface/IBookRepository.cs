using Domain.Models;
using System.Collections.Generic;


namespace Domain.Interface
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        public void Add(Book addBook);
        Book GetByName(string name);
        Book GetById(int id);
        void Remove(int id);
        void Update(Book book);
        void Borrow(int id);
        IEnumerable<Book> GetAllBorrowed();
        Book GetBorrowedById(int id);
        void ReturnBook(int id);
    }
}
