using Atheneum.DataAccess.Models;
using Atheneum.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace Atheneum.DataAccess
{
    public class AtheneumContext : DbContext
    {
        private IConfigurationRoot _configuration;

        public AtheneumContext(IConfigurationRoot configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Periodical> Periodicals { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
        }
    }
}
