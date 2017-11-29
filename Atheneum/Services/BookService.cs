using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Atheneum.DataAccess.Models;
using Atheneum.DataAccess.Repositories;
using Atheneum.DataAccess;

namespace Atheneum.Services
{
    public class BookService
    {
        private BookRepository _bookRepository;
        private readonly AtheneumContext _context;

        public BookService(AtheneumContext context)
        {
            _context = context;
            _bookRepository = new BookRepository(_context);
        }

        public IList<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }
        public void CreateBook(Book book)
        {
            _bookRepository.CreateBook(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        public void DestroyBook(string id)
        {
            _bookRepository.DestroyBook(id);
        }
        public Book GetBook(string id)
        {
            return _bookRepository.GetBook(id);
        }

        public List<Book> GetCheckedBooks()
        {
            return _bookRepository.GetCheckedBooks();
        }
    }
}