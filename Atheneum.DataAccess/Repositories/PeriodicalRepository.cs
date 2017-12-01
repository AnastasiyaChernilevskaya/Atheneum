using Atheneum.DataAccess.Enums;
using Atheneum.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.DataAccess.Repositories
{
    public class PeriodicalRepository
    {
        private readonly AtheneumContext _context;

        public PeriodicalRepository(AtheneumContext context)
        {
            _context = context;
        }

        public IList<Periodical> GetPeriodicals()
        {
            var result = new List<Periodical>();
            result = _context.Periodicals.ToList();

            return result;
        }

        public void CreatePeriodical(Periodical periodical)
        {
            var entity = new Periodical();

            entity.IncludeToFile = periodical.IncludeToFile;
            entity.Name = periodical.Name;
            entity.Publisher = periodical.Publisher;

            entity.LibraryType = LibraryType.Periodical;

            entity.YearOfPublishing = periodical.YearOfPublishing;

            _context.Periodicals.Add(entity);
            _context.SaveChanges();
        }

        public void UpdatePeriodical(Periodical periodical)
        {
            var entity = GetPeriodical(periodical.Id);

            entity.IncludeToFile = periodical.IncludeToFile;
            entity.Name = periodical.Name;
            entity.Publisher = periodical.Publisher;

            entity.YearOfPublishing = periodical.YearOfPublishing;

            _context.SaveChanges();
        }

        public void DestroyPeriodical(string id)
        {
            _context.Periodicals.Remove(GetPeriodical(id));
            _context.SaveChanges();
        }

        public Periodical GetPeriodical(string id)
        {
            return GetPeriodicals().FirstOrDefault(p => p.Id == id);
        }
        public List<Periodical> GetCheckedPeriodicals()
        {
            var result = new List<Periodical>();
            foreach (Periodical periodical in GetPeriodicals())
            {
                if (periodical.IncludeToFile)
                {
                    result.Add(periodical);
                }
            }
            return result;
        }
    }
}
