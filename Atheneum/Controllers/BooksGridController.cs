using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atheneum.DataAccess;
using Atheneum.DataAccess.Models;
using Atheneum.DataAccess.Repositories;
using Atheneum.Services;

namespace Atheneum.Controllers
{
    [Produces("application/json")]
    [Route("api/BooksGridAPI")]
    public class BooksGridAPI : Controller
    {
        private BookService _bookService;
        public IActionResult Index()
        {
            return View();
        }

        private readonly AtheneumContext _context;

        public BooksGridAPI(AtheneumContext context)
        {
            _context = context;
            _bookService = new BookService(context);
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Book> GetBooks()
        {
            var book = _bookService.GetBooks();
            return book;
        }

        [HttpGet]
        [Route("Destroy/{id}")]
        public bool DestroyBook(string id)
        {
            try
            {
                _bookService.DestroyBook(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Edit")]
        public bool EditBook([FromBody]Book book)
        {
            try
            {
                _bookService.UpdateBook(book);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Add")]
        public bool AddBook([FromBody]Book book)
        {
            try
            {
                _bookService.CreateBook(book);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}