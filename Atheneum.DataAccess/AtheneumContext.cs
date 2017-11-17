using Atheneum.DataAccess.Models;
using Atheneum.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Atheneum.DataAccess
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Periodical>().ToTable("Periodical");
            modelBuilder.Entity<Newspaper>().ToTable("Newspaper");
        }

    }
}
