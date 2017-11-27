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
    [Route("api/MainGridAPI")]
    public class MainGridAPI : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        private readonly AtheneumContext _context;

        public MainGridAPI(AtheneumContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Book")]
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }


        [HttpGet]
        [Route("Newspaper")]
        public IEnumerable<Newspaper> GetNewspapers()
        {
            return _context.Newspapers;
        }

        [HttpGet]
        [Route("Periodical")]
        public IEnumerable<Periodical> GetPeriodicals()
        {
            return _context.Periodicals;
        }


        //[HttpGet]
        //[Route("Details/{id}")]
        //public IEnumerable<StudentDetails> GetStudentDetails(int id)
        //{
        //    return _context.StudentDetails.Where(i => i.StdID == id).ToList();
        //}
    }
}