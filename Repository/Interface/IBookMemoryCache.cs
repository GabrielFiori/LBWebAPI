using Domain.Models;
using System.Collections.Generic;



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
    }
}
