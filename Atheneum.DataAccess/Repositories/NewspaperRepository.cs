using Atheneum.DataAccess.Enums;
using Atheneum.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.DataAccess.Repositories
{
    public class NewspaperRepository
    {
        private readonly AtheneumContext _context;

        public NewspaperRepository(AtheneumContext context)
        {
            _context = context;
        }

        public List<Newspaper> GetNewspapers()
        {
            var result = new List<Newspaper>();
            result = _context.Newspapers.ToList();

            return result;
        }

        public void CreateNewspaper(Newspaper newspaper)
        {
            var entity = new Newspaper();

            entity.IncludeToFile = newspaper.IncludeToFile;
            entity.Name = newspaper.Name;
            entity.Publisher = newspaper.Publisher;

            entity.LibraryType = LibraryType.Newspaper;

            entity.YearOfPublishing = newspaper.YearOfPublishing;

            _context.Newspapers.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateNewspaper(Newspaper newspaper)
        {
            var entity = GetNewspaper(newspaper.Id);

            entity.IncludeToFile = newspaper.IncludeToFile;
            entity.Name = newspaper.Name;
            entity.Publisher = newspaper.Publisher;

            entity.YearOfPublishing = newspaper.YearOfPublishing;

            _context.SaveChanges();
        }

        public void DestroyNewspaper(string id)
        {
            _context.Newspapers.Remove(GetNewspaper(id));
            _context.SaveChanges();
        }

        public Newspaper GetNewspaper(string id)
        {
            return GetNewspapers().FirstOrDefault(p => p.Id == id);
        }
        public List<Newspaper> GetCheckedNewspapers()
        {
            var result = new List<Newspaper>();
            foreach (Newspaper newspaper in GetNewspapers())
            {
                if (newspaper.IncludeToFile)
                {
                    result.Add(newspaper);
                }
            }
            return result;
        }
    }
}
