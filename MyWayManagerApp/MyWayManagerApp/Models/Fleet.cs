using System;
using System.Collections.Generic;


namespace MyWayManagerApp.Models
{
    public partial class Fleet
    {
         public Fleet()
        {
            Cars = new List<Car>();
        }

        public int FleetId { get; set; }
        public int? ManagerId { get; set; }
        public string FleetDrivingLimit { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}
