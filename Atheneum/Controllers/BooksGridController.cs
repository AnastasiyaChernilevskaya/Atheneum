using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atheneum.DataAccess;
using Atheneum.DataAccess.Models;

namespace Atheneum.Controllers
{
[Produces("application/json")]
    [Route("api/BooksGridAPI")]
    public class BooksGridAPI : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        private readonly AtheneumContext _context;

        public BooksGridAPI(AtheneumContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Books")]
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }

        [HttpGet]
        [Route("Destroy/{id}")]
        public void DestroyLibraryItem(string id)
        {
            var book = _context.Books.ToList().FirstOrDefault(p => p.id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        //[HttpGet]
        //[Route("Details/{id}")]
        //public IEnumerable<StudentDetails> GetStudentDetails(int id)
        //{
        //    return _context.StudentDetails.Where(i => i.StdID == id).ToList();
        //}
    }
}