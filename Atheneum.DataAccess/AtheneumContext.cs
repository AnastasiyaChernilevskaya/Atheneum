using Atheneum.DataAccess.Models;
using Atheneum.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace Atheneum.DataAccess
{
    public class AtheneumContext : DbContext
    {
        public AtheneumContext(DbContextOptions<AtheneumContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Periodical> Periodicals { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }

    }
}
