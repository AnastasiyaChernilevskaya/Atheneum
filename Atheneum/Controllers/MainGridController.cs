using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atheneum.DataAccess;
using Atheneum.DataAccess.Models;
using Atheneum.Services;
using Atheneum.DataAccess.Enums;

namespace Atheneum.Controllers
{
    [Produces("application/json")]
    [Route("api/MainGridAPI")]
    public class MainGridAPI : Controller
    {
        private LibraryService _libraryService;
        private readonly AtheneumContext _context;

        public MainGridAPI(AtheneumContext context)
        {
            _context = context;
            _libraryService = new LibraryService(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Atheneum")]
        public IEnumerable<BaseEntity> GetEntitys()
        {
            return _libraryService.GetLibrary();
        }

        [HttpGet]
        [Route("Destroy/{id}/{type}")]
        public void DestroyLibraryItem(string id, int entityLibraryType)
        {
            _libraryService.DestroyLibraryItem(id, entityLibraryType);
        }


        //[HttpGet]
        //[Route("Details/{id}")]
        //public IEnumerable<StudentDetails> GetStudentDetails(int id)
        //{
        //    return _context.StudentDetails.Where(i => i.StdID == id).ToList();
        //}
    }
}