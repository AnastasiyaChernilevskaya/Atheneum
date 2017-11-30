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
        private readonly AtheneumContext _context;

        public LibraryRepository(AtheneumContext context)
        {
            _context = context;
        }

        public List<BaseEntity> GetEntities()
        {
            var result = new List<BaseEntity>();

            result.AddRange(_context.Books);
            result.AddRange(_context.Newspapers);
            result.AddRange(_context.Periodicals);

            return result;
        }

        public void UpdateEntityChack(BaseEntity baseEntity)
        {
            var id = baseEntity.Id;
            if (baseEntity.LibraryType == LibraryType.Book)
            {
                var _repository = new BookRepository(_context);
                var book = _repository.GetBook(id);
                book.Name = baseEntity.Name;
                book.Publisher = baseEntity.Publisher;
                book.IncludeToFile = baseEntity.IncludeToFile;
                if (book != null)
                {
                    _repository.UpdateBook(book);
                }
                return;
            }
            if (baseEntity.LibraryType == LibraryType.Newspaper)
            {
                var _repository = new NewspaperRepository(_context);
                var newspaper = _repository.GetNewspaper(id);
                newspaper.Name = baseEntity.Name;
                newspaper.Publisher = baseEntity.Publisher;
                newspaper.IncludeToFile = baseEntity.IncludeToFile;
                if (newspaper != null)
                {
                    _repository.UpdateNewspaper(newspaper);
                }
                return;
            }
            if (baseEntity.LibraryType == LibraryType.Periodical)
            {
                var _repository = new PeriodicalRepository(_context);
                var periodical = _repository.GetPeriodical(id);
                periodical.Name = baseEntity.Name;
                periodical.Publisher = baseEntity.Publisher;
                periodical.IncludeToFile = baseEntity.IncludeToFile;
                if (periodical != null)
                {
                    _repository.UpdatePeriodical(periodical);
                }
            }
        }

        public void DestroyEntity(string id, int entityLibraryType)
        {
            if (entityLibraryType == (int)LibraryType.Book)
            {
                var _repository = new BookRepository(_context);
                _repository.DestroyBook(id);
            }
            if (entityLibraryType == (int)LibraryType.Newspaper)
            {
                var _repository = new NewspaperRepository(_context);
                _repository.DestroyNewspaper(id);
            }
            if (entityLibraryType == (int)LibraryType.Periodical)
            {
                var _repository = new PeriodicalRepository(_context);
                _repository.DestroyPeriodical(id);
            }
        }

        public BaseEntity GetEntity(string id, int entityLibraryType)
        {
            if (entityLibraryType == (int)LibraryType.Book)
            {
                var _repository = new BookRepository(_context);
                return _repository.GetBook(id);
            }
            if (entityLibraryType == (int)LibraryType.Newspaper)
            {
                var _repository = new NewspaperRepository(_context);
                return _repository.GetNewspaper(id);
            }
            if (entityLibraryType == (int)LibraryType.Periodical)
            {
                var _repository = new PeriodicalRepository(_context);
                return _repository.GetPeriodical(id);
            }
            return null;
        }

        public List<BaseEntity> GetCheckedEntitys()
        {
            var result = new List<BaseEntity>();
            foreach (BaseEntity entity in GetEntities())
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
