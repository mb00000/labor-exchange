using Microsoft.EntityFrameworkCore;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Infrastructure.ApplicationContext
{
    public class EFContext : DbContext
    {
        public EFContext()
        {
        }
        public EFContext(DbContextOptions<EFContext> options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LaborExchangeDB; Trusted_Connection = True;");
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<WorkOffer> WorkOffers { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}