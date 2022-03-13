using System;
using System.Collections.Generic;


namespace MyWayManagerApp.Models
{
    public partial class Car
    {
        public Car()
        {
            RoutteCars = new List<RoutteCar>();
        }

        public int CarId { get; set; }
        public int? FleetId { get; set; }
        public string CarCurrentLocation { get; set; }
        public int? CarNumSeats { get; set; }
        public int? CarNumber { get; set; }
        public int? CarTypeId { get; set; }
        public int? CarTank { get; set; }

        public virtual CarType CarType { get; set; }
        public virtual Fleet Fleet { get; set; }
        public virtual List<RoutteCar> RoutteCars { get; set; }
    }
}
