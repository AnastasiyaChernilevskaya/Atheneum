﻿using System;
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
        [Route("Atheneum")]
        public IEnumerable<BaseEntity> GetEntitys()
        {
            var result = new List<BaseEntity>();

            result.AddRange(_context.Books);
            result.AddRange(_context.Newspapers);
            result.AddRange(_context.Periodicals);

            return result;
        }

        //[HttpGet]
        //[Route("Details/{id}")]
        //public IEnumerable<StudentDetails> GetStudentDetails(int id)
        //{
        //    return _context.StudentDetails.Where(i => i.StdID == id).ToList();
        //}
    }
}