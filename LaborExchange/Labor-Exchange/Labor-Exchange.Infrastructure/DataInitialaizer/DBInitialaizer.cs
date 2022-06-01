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
                new Company {Contacts = "q", Name = "UI" },
                new Company {Contacts = "05", Name = "uyrea" },
            }; 

            context.Companies.AddRange(companies);
            context.SaveChanges();

            var workOffers = new List<WorkOffer>
            {
                new WorkOffer {Position = "LA", Conditions = "sd", Housing = "sde", Requirements = "dfefr"},
                new WorkOffer {Position = "fsdfsd", Conditions = "sfsdf", Housing = "sdf", Requirements = "ghkjfgj"},
            };

            context.WorkOffers.AddRange(workOffers);
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="64", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884" },
                new Employee {Name="68", Profession ="54", Education ="65478", Contacts = "567", Housing = "4", ReasonOfDismisal = "435", MartialStatus="64", LastWork="57884", }

            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
