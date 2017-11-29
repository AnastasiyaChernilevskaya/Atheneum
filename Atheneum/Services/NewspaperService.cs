using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using Atheneum.DataAccess.Models;
using Atheneum.DataAccess.Repositories;

namespace Atheneum.Services
{
    public class NewspaperService
    {
        private NewspaperRepository _newspaperRepository;
        public NewspaperService()
        {
            _newspaperRepository = new NewspaperRepository();
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