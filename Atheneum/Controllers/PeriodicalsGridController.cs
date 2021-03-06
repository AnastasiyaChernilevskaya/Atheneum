﻿using System;
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
    [Route("api/PeriodicalGridAPI")]
    public class PeriodicalGridAPI : Controller
    {
        private PeriodicalService _periodicalService;
        public IActionResult Index()
        {
            return View();
        }

        private readonly AtheneumContext _context;

        public PeriodicalGridAPI(AtheneumContext context)
        {
            _context = context;
            _periodicalService = new PeriodicalService(context);
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Periodical> GetPeriodicals()
        {var periodical = _periodicalService.GetPeriodicals();
            return periodical;
        }

        [HttpGet]
        [Route("Destroy/{id}")]
        public bool DestroyPeriodical(string id)
        {
            try
            {
                _periodicalService.DestroyPeriodical(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Edit")]
        public bool EditPeriodical([FromBody]Periodical periodical)
        {
            try
            {
                _periodicalService.UpdatePeriodical(periodical);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Add")]
        public bool AddBook([FromBody]Periodical periodical)
        {
            try
            {
                _periodicalService.CreatePeriodical(periodical);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }        
    }
}