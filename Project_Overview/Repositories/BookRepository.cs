using Project_Overview.Classes;
using Project_Overview.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Overview.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();

        public void Add(Book book) => books.Add(book);
        public void Update(Book book)
        {
            var existing = GetById(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.IsBorrowed = book.IsBorrowed;
            }
        }
        public void Delete(Guid id) => books.RemoveAll(b => b.Id == id);
        public Book GetById(Guid id) => books.FirstOrDefault(b => b.Id == id);
        public List<Book> GetAll() => books;
        public List<Book> GetAvailableBooks() => books.Where(b => !b.IsBorrowed).ToList();
    }
}
