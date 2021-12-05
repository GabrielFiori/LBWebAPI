using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Interface
{
    public interface IBookMemoryCache
    {
        List<Book> GetAll();
        List<Book> GetAllBorrowed();
        void SaveAll(List<Book> books);
        void SaveAllBorrow(List<Book> books);
        void Add(Book addBook);
        List<Book> DeserializeBook(string jsonSerialized);
        string SerializeBook(List<Book> books);
        int GetNewId();
        Book GetByName(string name);
        Book GetById(int id);
        void Remove(int id);
        void Borrow(int id);
        void UpdateBorrowList(Book bookBorrowed);
        Book GetBorrowedById(int id);
        void ReturnBook(int id);
        void Update(Book book);
        //GetById(int id);
        //RegisterNewBook(BookApiModel book);
        //DeleteBook(int id);
        //BorrowBook(int id);
        //ReturnBook(int id);
        //BorrowBooks();
    }
}
