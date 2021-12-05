using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();

        int GetNewId();

        public void Add(Book addBook);

        Book GetByName(string name);

        Book GetById(int id);

        void Remove(int id);

        void Update(Book book);

        void Borrow(int id);

        IEnumerable<Book> GetAllBorrowed();

        Book GetBorrowedById(int id);

        void ReturnBook(int id);


        //GetById(int id);
        //RegisterNewBook(BookApiModel book);
        //DeleteBook(int id);
        //BorrowBook(int id);
        //ReturnBook(int id);
        //BorrowBooks();

    }
}
