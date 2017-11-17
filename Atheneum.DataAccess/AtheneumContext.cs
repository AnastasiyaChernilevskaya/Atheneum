using Atheneum.DataAccess.Models;
using Atheneum.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Atheneum
{
    public class AtheneumContext : DbContext
    {
        public AtheneumContext() : base()
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Periodical> Periodicals { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }

        public static AtheneumContext Create()
        {
            return new AtheneumContext();
        }

    }
}
