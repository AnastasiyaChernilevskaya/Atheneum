using Atheneum.DataAccess.Models;
using Atheneum.DataAccess.Enums;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Atheneum.DataAccess
{
    public class AtheneumDbInitializer
    {
        public AtheneumDbInitializer(AtheneumContext context)
        {
        }

        public static void Initialize(AtheneumContext context)
        {
            context.Database.EnsureCreated();
            if (context.Books.Any())
            {
                return;
            }

            context.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Publisher = "veselka", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Book });
            context.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Publisher = "veselka", IncludeToFile = false, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Book });
            context.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Publisher = "veselka", IncludeToFile = false, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Book });
            context.Books.Add(new Book { Name = "Война и мир1", Author = "Л. Толстой1", Publisher = "veselkas", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Book });
            context.Books.Add(new Book { Name = "Отцы и дети1", Author = "И. Тургенев1", Publisher = "veselkas", IncludeToFile = false, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Book });
            context.Books.Add(new Book { Name = "Чайка1", Author = "А. Чехов1", Publisher = "veselkas", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Book });

            context.Newspapers.Add(new Newspaper { Name = "1sdfg", Publisher = "aerg", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Newspaper });
            context.Newspapers.Add(new Newspaper { Name = "2sdfg", Publisher = "aerg", IncludeToFile = false, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Newspaper });
            context.Newspapers.Add(new Newspaper { Name = "3sdfg", Publisher = "aerg", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Newspaper });

            context.Periodicals.Add(new Periodical { Name = "1rdghaersdfg", Publisher = "straerg", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Periodical });
            context.Periodicals.Add(new Periodical { Name = "2sstrjdfg", Publisher = "aerstrjg", IncludeToFile = false, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Periodical });
            context.Periodicals.Add(new Periodical { Name = "3sstrjdfg", Publisher = "aersrtjg", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Periodical });
            context.Periodicals.Add(new Periodical { Name = "4sdstrjfg", Publisher = "aesrtjrg", IncludeToFile = false, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Periodical });
            context.Periodicals.Add(new Periodical { Name = "5sstrjdfg", Publisher = "aaherahg", IncludeToFile = true, YearOfPublishing = DateTime.Now, LibraryType = LibraryType.Periodical });

            context.SaveChanges();
        }
    }
}
