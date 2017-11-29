using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atheneum.DataAccess;
using Atheneum.DataAccess.Models;
using Atheneum.Services;

namespace Atheneum.Controllers
{
[Produces("application/json")]
    [Route("api/BooksGridAPI")]
    public class BooksGridAPI : Controller
    {
        private BookService _bookService;
        private readonly AtheneumContext _context;

        public BooksGridAPI(AtheneumContext context)
        {
            _context = context;
            _bookService = new BookService(_context);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Books")]
        public IEnumerable<Book> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [HttpGet]
        [Route("Destroy/{id}")]
        public void DestroyBook(string id)
        {
            _bookService.DestroyBook(id);
        }

        [HttpGet]
        [Route("Edit/{book}")]
        public void UpdateBook(Book book)
        {
            _bookService.UpdateBook(book);
        }

        //[HttpGet]
        //[Route("Details/{id}")]
        //public IEnumerable<StudentDetails> GetStudentDetails(int id)
        //{
        //    return _context.StudentDetails.Where(i => i.StdID == id).ToList();
        //}
    }
}