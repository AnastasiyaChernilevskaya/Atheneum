using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using Atheneum.DataAccess.Models;
using Atheneum.DataAccess.Repositories;
using Atheneum.DataAccess;

namespace Atheneum.Services
{
    public class NewspaperService
    {
        private NewspaperRepository _newspaperRepository;
        private readonly AtheneumContext _context;

        public NewspaperService(AtheneumContext context)
        {
            _context = context;
            _newspaperRepository = new NewspaperRepository(_context);
        }

        public List<Newspaper> GetNewspapers()
        {
            return _newspaperRepository.GetNewspapers();
        }

        public void CreateNewspaper(Newspaper newspaper)
        {
            _newspaperRepository.CreateNewspaper(newspaper);
        }

        public void UpdateNewspaper(Newspaper newspaper)
        {
            _newspaperRepository.UpdateNewspaper(newspaper);
        }

        public void DestroyNewspaper(string id)
        {
            _newspaperRepository.DestroyNewspaper(id);
        }

        public Newspaper GetNewspaper(string id)
        {
            return _newspaperRepository.GetNewspaper(id);
        }

        public List<Newspaper> GetCheckedNewspapers()
        {
            return _newspaperRepository.GetCheckedNewspapers();
        }
    }
}