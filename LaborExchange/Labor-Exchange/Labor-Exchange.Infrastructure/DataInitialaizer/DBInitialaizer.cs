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

            var workOffers = new List<WorkOffer>
            {
                new WorkOffer {dateTime = DateTime.UtcNow, IsStoraged = true, Company="Pizzeria", Position = "Driver", Conditions = "7 hours of working day, 1000$ - per month", Housing = "Flat", Requirements = "higher education", Contacts="324516552"},
                new WorkOffer {dateTime = DateTime.UtcNow, IsStoraged = true, Company="Shop", Position = "Cashier", Conditions = "8 hours of working day, 1200$ - per month", Housing = "Flat", Requirements = "middle education", Contacts="546546568"},
                new WorkOffer {Company="Starbucks", Position = "Cashier", Conditions = "8 hours of working day, 1000$ - per month", Housing = "House", Requirements = "No", Contacts="545316546"},
                new WorkOffer {Company="Asus", Position = "Programmer", Conditions = "7 hours of working day, 4000$ - per month", Housing = "Flat", Requirements = "higher education", Contacts="654651231"},
                new WorkOffer {Company="EPAM", Position = "Programmer", Conditions = "8 hours of working day, 2000$ - per month", Housing = "House", Requirements = "higher education", Contacts="455645645"},
                new WorkOffer {Company="NIX", Position = "Programmer", Conditions = "5 hours of working day, 5000$ - per month", Housing = "House", Requirements = "higher education", Contacts="564351545"},
                new WorkOffer {Company="MSI", Position = "electrician", Conditions = "8 hours of working day, 1500$ - per month", Housing = "Flat", Requirements = "higher education", Contacts="456456545"},
                new WorkOffer {Company="Samsung", Position = "Director", Conditions = "8 hours of working day, 50000$ - per month", Housing = "Flat", Requirements = "higher education", Contacts = "541327569"},
                new WorkOffer {Company="Apple", Position = "Marketer", Conditions = "8 hours of working day, 1000$ - per month", Housing = "House", Requirements = "higher education", Contacts = "561321654"},
                new WorkOffer {Company="Apple", Position = "Programmer", Conditions = "6 hours of working day, 3000$ - per month", Housing = "Flat", Requirements = "higher education", Contacts="534548542"},
                new WorkOffer {Company="Apple", Position = "Director", Conditions = "8 hours of working day, 50000$ - per month", Housing = "Flat", Requirements = "higher education", Contacts = "546351478"},
                new WorkOffer {Company="Merceges-Benz", Position = "Constructor", Conditions = "8 hours of working day, 10000$ - per month", Housing = "House", Requirements = "higher education", Contacts = "654321354"},
                new WorkOffer {Company="Apple", Position = "Cleaner", Conditions = "9 hours of working day, 200$ - per month$", Housing = "Flat", Requirements = "higher education", Contacts = "567564564"},
            };

            context.WorkOffers.AddRange(workOffers);
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee {Name="Andrew Stewart", Profession ="Programmer", Education ="higher education", Contacts = "123456789", Housing = "Flat", ReasonOfDismisal = "downsizing", MartialStatus="Maried", LastWork="Hotel, position - administrator", Requirements = "working no more than 6 hours per day" },
                new Employee {Name="Alex Simpson", Profession ="Doctor", Education ="middle education", Contacts = "121451231", Housing = "Flat", ReasonOfDismisal = "downsizing", MartialStatus="single", LastWork="Restaurant, position - director", Requirements = "no less than 2000$ per month" },
                new Employee {Name="Michael Newel", Profession ="Cook", Education ="without education", Contacts = "526456426", Housing = "Flat", ReasonOfDismisal = "downsizing", MartialStatus="Maried", LastWork="Cafe, position - administrator", Requirements = "no less than 1000$ per month" },
                new Employee {Name="Nickolas Geek", Profession ="Mechanic", Education ="middle education", Contacts = "897654325", Housing = "Flat", ReasonOfDismisal = "downsizing", MartialStatus="Maried", LastWork="Company, position - mechanic" , Requirements = "no less than 500$ per month"},
                new Employee {Name="Nazar Braun", Profession ="Marketer", Education ="middle education", Contacts = "654654658", Housing = "house", ReasonOfDismisal = "downsizing", MartialStatus="Single", LastWork="Factory, position - marketer", Requirements = "working no more than 8 hours per day" },
                new Employee {Name="Stewe McTomy", Profession ="Technologist", Education ="higher education", Contacts = "9465465485", Housing = "Flat", ReasonOfDismisal = "downsizing", MartialStatus="Maried", LastWork="state bureau, position - technologist" , Requirements = "working no more than 7 hours per day"},
                new Employee {Name="Vitaliy Bell", Profession ="Economist", Education ="higher education", Contacts = "654845567", Housing = "house", ReasonOfDismisal = "downsizing", MartialStatus="Single", LastWork="Shop, position - economist", Requirements = "no less than 3000$ per month" },
                new Employee {Name="Taras Greenwood", Profession ="Driver", Education ="higher education", Contacts = "5674841687", Housing = "Flat", ReasonOfDismisal = "conflict", MartialStatus="Single", LastWork="Shop, position - cashier", Requirements = "working no more than 7 hours per day" },
                new Employee {Name="Adriano Chelentano", Profession ="Copywritter", Education ="higher education", Contacts = "456545654", Housing = "house", ReasonOfDismisal = "absenteeism", MartialStatus="Single", LastWork="Beaty studio, position - stylist", Requirements = "working no more than 8 hours per day" },
                new Employee {Name="Vito Scorcesse", Profession ="Astronaut", Education ="higher education", Contacts = "654654564", Housing = "Flat", ReasonOfDismisal = "downsizing", MartialStatus="Maried", LastWork="Military object, position - economist", Requirements = "no less than 1000$ per month" },
                new Employee {Name="Tomas Rodgers", Profession ="Miliratist", Education ="higher education", Contacts = "5646546546", Housing = "Flat", ReasonOfDismisal = "downsizing", MartialStatus="Maried", LastWork="Hotel, position - administrator", Requirements = "no less than 700$ per month" },
                new Employee {Name="Dmytro Rochfeller", Profession ="Stylist", Education ="higher education", Contacts = "567854289", Housing = "house", ReasonOfDismisal = "downsizing", MartialStatus="Maried", LastWork="Hotel, position - director", Requirements = "no less than 1500$ per month" },
                new Employee {Name="Volodymyr Pounds", Profession ="Hairdresser", Education ="higher education", Contacts = "567564564", Housing = "house", ReasonOfDismisal = "downsizing", MartialStatus="Single", LastWork="School, position - teacher", Requirements = "no less than 500$ per month" },
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
