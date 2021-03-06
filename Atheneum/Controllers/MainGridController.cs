﻿using System;
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
        public bool DestroyLibraryItem(string id, int type)
        {
            try
            {
                _libraryService.DestroyLibraryItem(id, type);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Edit")]
        public bool EditBook([FromBody]BaseEntity entity)
        {
            try
            {
                _libraryService.UpdateLibrary(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}