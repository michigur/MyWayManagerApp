using System;
using System.Collections.Generic;



namespace MyWayManagerApp.Models
{
    public partial class Client
    {
        public Client()
        {
            RoutteCars = new HashSet<RoutteCar>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientsLastName { get; set; }
        public string ClientsEmail { get; set; }
        public string ClientsGenedr { get; set; }
        public DateTime ClientsBirthDay { get; set; }
        public string ClientsUsername { get; set; }
        public string ClientsPassword { get; set; }
        public string ClientCreditCardNumber { get; set; }
        public DateTime? ClientCreditCardDate { get; set; }
        public int? ClientCreditCardCvv { get; set; }
        public string ClientCurrentLocation { get; set; }

        public virtual ICollection<RoutteCar> RoutteCars { get; set; }
    }
}
