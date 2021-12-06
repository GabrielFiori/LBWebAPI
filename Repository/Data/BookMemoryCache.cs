using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using Repository.Interface;
using Domain.Models;
using System.Text.Json;

namespace Repository.Data
{
    public class BookMemoryCache : IBookMemoryCache
    {
        private readonly IMemoryCache _memoryCache;
        private const string bookKey = "Books";
        private const string bookBorrowKey = "BooksBorrowed";

        public BookMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<Book> DeserializeBook(string jsonSerialized)
        {
            return JsonSerializer.Deserialize<List<Book>>(jsonSerialized);
        }

        public string SerializeBook(List<Book> books)
        {
            return JsonSerializer.Serialize(books);
        }

        public List<Book> GetAll()
        {
            if (_memoryCache.TryGetValue(bookKey, out string bvalues))
            {
                List<Book> dbBooks = DeserializeBook(bvalues);
                return dbBooks;
            }

            List<Book> bookList = new();
            bookList.Add( new Book(1, "Harry Potter", 2) );
            bookList.Add( new Book(2, "Sherlock Holmes", 1) ); 
            
            SaveAll(bookList);

            return bookList;
        }

        public void SaveAll(List<Book> books)
        {
            string booksSerialized = SerializeBook(books);
            _memoryCache.Set(bookKey, booksSerialized);
        }

        public int GetNewId()
        {
            List<Book> dbBooks = GetAll();
            return dbBooks.Max(x => x.Id) + 1;
        }

        public void Add(Book book)
        {
            List<Book> dbBooks = GetAll();
            book.Id = GetNewId();
            dbBooks.Add(book);
            SaveAll(dbBooks);
        }

        public Book GetByName(string name)
        {
            List<Book> dbBooks = GetAll();
            return dbBooks.Find(x => x.Name == name);
        }

        public Book GetById(int id)
        {
            List<Book> dbBooks = GetAll();
            return dbBooks.Find(x => x.Id == id);
        }

        public void Remove(int id)
        {
            List<Book> dbBooks = GetAll();

            dbBooks.Remove(dbBooks.Find(x => x.Id == id));

            SaveAll(dbBooks);

        }

        public void Update(Book book)
        {
            List<Book> dbBooks = GetAll();

            Book SelectedBook = dbBooks.Find(x => x.Id == book.Id);

            SelectedBook.Name = book.Name;
            SelectedBook.Quantity = book.Quantity;

            SaveAll(dbBooks);
        }

        public List<Book> GetAllBorrowed()
        {
            if (_memoryCache.TryGetValue(bookBorrowKey, out string bvalues))
            {
                List<Book> dbBooks = DeserializeBook(bvalues);
                return dbBooks;
            }

            List<Book> bookList = new();

            SaveAllBorrow(bookList);

            return bookList;
        }

        public void SaveAllBorrow(List<Book> books)
        {
            string booksSerialized = SerializeBook(books);
            _memoryCache.Set(bookBorrowKey, booksSerialized);
        }


        public void Borrow(int id)
        {
            List<Book> dbBooks = GetAll();

            Book SelectedBook = dbBooks.Find(x => x.Id == id);

            SelectedBook.Quantity -= 1;

            SaveAll(dbBooks);

            UpdateBorrowList(SelectedBook);
        }

        public void UpdateBorrowList(Book bookBorrowed)
        {
            List<Book> dbBooks = GetAllBorrowed();

            Book dbBookBorrowed = dbBooks.Find(x => x.Id == bookBorrowed.Id);

            if (dbBookBorrowed == null)
            {
                bookBorrowed.Quantity = 1;
                dbBooks.Add(bookBorrowed);
                SaveAllBorrow(dbBooks);
                return;
            }

            dbBookBorrowed.Quantity += 1;

            SaveAllBorrow(dbBooks);
        }

        public Book GetBorrowedById(int id)
        {
            List<Book> dbBooks = GetAllBorrowed();
            return dbBooks.Find(x => x.Id == id);
        }

        public void ReturnBook(int id)
        {
            List<Book> dbBooks = GetAllBorrowed();

            Book dbBookBorrowed = dbBooks.Find(x => x.Id == id);

            if (dbBookBorrowed.Quantity == 1)
            {
                dbBooks.Remove(dbBooks.Find(x => x.Id == id));
            }
            else
            {
                dbBookBorrowed.Quantity -= 1;
            }
            AddQuantityBook(dbBookBorrowed.Id, 1);
            SaveAllBorrow(dbBooks);
        }

        public void AddQuantityBook(int id,int ammout)
        {
            List<Book> dbBooks = GetAll();

            Book SelectedBook = dbBooks.Find(x => x.Id == id);

            SelectedBook.Quantity += ammout;

            SaveAll(dbBooks);

        }
    }
}
