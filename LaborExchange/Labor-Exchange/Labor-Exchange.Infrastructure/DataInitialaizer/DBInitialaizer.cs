using Labor_Exchange.Infrastructure.ApplicationContext;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Infrastructure.DataInitialaizer
{
    public static class DBInitialaizer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var companies = new List<Company>
            {
                new Company { Id = 0, Contacts = "q", Name = "UI" },
                new Company { Id = 1, Contacts = "05", Name = "uyrea" },
            }; 

            context.Companies.AddRange(companies);
            context.SaveChanges();

            var workOffers = new List<WorkOffer>
            {
                new WorkOffer { Id = 0, Position = "LA", Conditions = "sd", Housing = "sde", Requirements = "dfefr"},
                new WorkOffer { Id = 1, Position = "fsdfsd", Conditions = "sfsdf", Housing = "sdf", Requirements = "ghkjfgj"},
            };

            context.WorkOffers.AddRange(workOffers);
            context.SaveChanges();
        }
    }
}
