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
    [Route("api/NewspaperGridAPI")]
    public class NewspaperGridAPI : Controller
    {
        private NewspaperService _newspaperService;
        public IActionResult Index()
        {
            return View();
        }

        private readonly AtheneumContext _context;

        public NewspaperGridAPI(AtheneumContext context)
        {
            _context = context;
            _newspaperService = new NewspaperService(context);
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Newspaper> GetNewspapers()
        {
            var newspaper = _newspaperService.GetNewspapers();
            return newspaper;
        }

        [HttpGet]
        [Route("Destroy/{id}")]
        public bool DestroyNewspaper(string id)
        {
            try
            {
                _newspaperService.DestroyNewspaper(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Edit")]
        public bool EditBook([FromBody]Newspaper newspaper)
        {
            try
            {
                _newspaperService.UpdateNewspaper(newspaper);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Add")]
        public bool AddBook([FromBody]Newspaper newspaper)
        {
            try
            {
                _newspaperService.CreateNewspaper(newspaper);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}