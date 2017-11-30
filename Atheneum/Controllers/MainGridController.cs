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
    [Route("api/MainGridAPI")]
    public class MainGridAPI : Controller
    {
        private readonly AtheneumContext _context;
        private LibraryService _libraryService;


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
        [Route("Get")]
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

        [HttpPost]
        [Route("Edit")]
        public void EditBook([FromBody]BaseEntity entity)
        {
            _libraryService.UpdateLibrary(entity);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBook([FromBody]Book book)
        {
            //_libraryService.DestroyLibraryItem(id, entityLibraryType);
        }

        //[HttpGet]
        //[Route("Details/{id}")]
        //public IEnumerable<StudentDetails> GetStudentDetails(int id)
        //{
        //    return _context.StudentDetails.Where(i => i.StdID == id).ToList();
        //}
    }
}