using Atheneum.DataAccess.Enums;
using Atheneum.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.DataAccess.Repositories
{
    public class BookRepository
    {

        private AtheneumContext _context;

        public BookRepository()
        {
            _context = new AtheneumContext();
        }

        public IList<Book> GetBooks()
        {
            var result = new List<Book>();
            result = _context.Books.ToList();

            return result;
        }

        public void CreateBook(Book book)
        {
            var entity = new Book();

            entity.IncludeToFile = book.IncludeToFile;
            entity.Name = book.Name;
            entity.Publisher = book.Publisher;

            entity.LibraryType = LibraryType.Book;

            entity.Author = book.Author;
            entity.YearOfPublishing = book.YearOfPublishing;

            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var entity = GetBook(book.id);
            entity.IncludeToFile = book.IncludeToFile;
            entity.Name = book.Name;
            entity.Publisher = book.Publisher;

            entity.Author = book.Author;
            entity.YearOfPublishing = book.YearOfPublishing;
            _context.SaveChanges();
        }

        public void DestroyBook(string id)
        {
            _context.Books.Remove(GetBook(id));
            _context.SaveChanges();
        }

        public Book GetBook(string id)
        {
            return GetBooks().FirstOrDefault(p => p.id == id);
        }
        public List<Book> GetCheckedBooks()
        {
            var result = new List<Book>();
            foreach (Book book in GetBooks())
            {
                if (book.IncludeToFile)
                {
                    result.Add(book);
                }
            }
            return result;
        }
    }
}
