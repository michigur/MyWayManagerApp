using System;
using System.Collections.Generic;


namespace MyWayManagerApp.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Fleets = new List<Fleet>();
        }

        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerLastName { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerGenedr { get; set; }
        public DateTime ManagerBirthDay { get; set; }
        public string ManagerUsername { get; set; }
        public string ManagerPassword { get; set; }
        public string ManagerType { get; set; }
        public bool? IsGlobalManager { get; set; }

        public virtual List<Fleet> Fleets { get; set; }
    }
}
