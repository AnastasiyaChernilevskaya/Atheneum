using Atheneum.DataAccess.Enums;
using Atheneum.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.DataAccess.Repositories
{
    public class LibraryRepository
    {
        private AtheneumContext _context;

        public LibraryRepository()
        {
            _context = new AtheneumContext();
        }

        public List<BaseEntity> GetEntitys()
        {
            var result = new List<BaseEntity>();

            result.AddRange(_context.Books);
            result.AddRange(_context.Newspapers);
            result.AddRange(_context.Periodicals);

            return result;
        }

        public void UpdateEntityChack(string id, LibraryType entityLibraryType)
        {
            var entity = GetEntitys().Where(x => x.id == id).FirstOrDefault();
            if (entityLibraryType == LibraryType.Book)
            {
                var _repository = new BookRepository();
                var book = _repository.GetBook(id);
                book.IncludeToFile = !book.IncludeToFile;
                if (book != null)
                {
                    _repository.UpdateBook(book);
                }
                return;
            }
            if (entityLibraryType == LibraryType.Newspaper)
            {
                var _repository = new NewspaperRepository();
                var newspaper = _repository.GetNewspaper(id);
                newspaper.IncludeToFile = !newspaper.IncludeToFile;
                if (newspaper != null)
                {
                    _repository.UpdateNewspaper(newspaper);
                }
                return;
            }
            if (entityLibraryType == LibraryType.Periodical)
            {
                var _repository = new PeriodicalRepository();
                var periodical = _repository.GetPeriodical(id);
                periodical.IncludeToFile = periodical.IncludeToFile;
                if (periodical != null)
                {
                    _repository.UpdatePeriodical(periodical);
                }
            }
        }

        public void DestroyEntity(string id, LibraryType entityLibraryType)
        {
            if (entityLibraryType == LibraryType.Book)
            {
                var _repository = new BookRepository();
                _repository.DestroyBook(id);
            }
            if (entityLibraryType == LibraryType.Newspaper)
            {
                var _repository = new NewspaperRepository();
                _repository.DestroyNewspaper(id);
            }
            if (entityLibraryType == LibraryType.Periodical)
            {
                var _repository = new PeriodicalRepository();
                _repository.DestroyPeriodical(id);
            }
        }

        public BaseEntity GetEntity(string id, LibraryType entityLibraryType)
        {
            if (entityLibraryType == LibraryType.Book)
            {
                var _repository = new BookRepository();
                return _repository.GetBook(id);
            }
            if (entityLibraryType == LibraryType.Newspaper)
            {
                var _repository = new NewspaperRepository();
                return _repository.GetNewspaper(id);
            }
            if (entityLibraryType == LibraryType.Periodical)
            {
                var _repository = new PeriodicalRepository();
                return _repository.GetPeriodical(id);
            }
            return null;
        }

        public List<BaseEntity> GetCheckedEntitys()
        {
            var result = new List<BaseEntity>();
            foreach (BaseEntity entity in GetEntitys())
            {
                if (entity.IncludeToFile)
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}
