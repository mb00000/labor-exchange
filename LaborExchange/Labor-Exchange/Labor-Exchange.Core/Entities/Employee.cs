namespace Labor_Exchange.Core.Entities
{
    public class Employee : EntityBase
    {
        public string Name { get; set; }

        public string Profession { get; set; }

        public string Education { get; set; }

        public string LastWork { get; set; }

        public string ReasonOfDismisal { get; set; }

        public string MartialStatus { get; set; }

        public string Housing { get; set; }

        public string Contacts { get; set; }
    }
}
