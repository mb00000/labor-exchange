namespace Labor_Exchange.Core.Entities
{
    public class WorkOffer : EntityBase
    {
        public string Company { get; set; }

        public string Position { get; set; }

        public string Conditions { get; set; }

        public string Housing { get; set; }

        public string Requirements { get; set; }

        public bool IsStoraged { get; set; } = false;

        public string Contacts { get; set; }
          
        public DateTime dateTime { get; set; }
    }
}
