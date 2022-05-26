using Microsoft.EntityFrameworkCore;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Infrastructure.ApplicationContext
{
    public class EFContext : DbContext
    {
        public EFContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LaborExchangeDB; Trusted_Connection = True;");
        }

        public DbSet<Employee> Users { get; set; }

        public DbSet<WorkOffer> Roles { get; set; }

        public DbSet<Company> UserTokens { get; set; }
    }
}