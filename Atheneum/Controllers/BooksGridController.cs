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
            return _bookService.GetBooks();
        }

        [HttpGet]
        [Route("Destroy/{id}")]
        public void DestroyBook(string id)
        {
            _bookService.DestroyBook(id);
        }

        [HttpPost]
        [Route("Edit")]
        public void EditBook([FromBody]Book book)
        {
            _bookService.UpdateBook(book);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBook([FromBody]Book book)
        {
            _bookService.CreateBook(book);
        }

        //[HttpGet]
        //[Route("Details/{id}")]
        //public IEnumerable<StudentDetails> GetStudentDetails(int id)
        //{
        //    return _context.StudentDetails.Where(i => i.StdID == id).ToList();
        //}
    }
}