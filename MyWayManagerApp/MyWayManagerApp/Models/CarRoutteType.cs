using System;
using System.Collections.Generic;


namespace MyWayManagerApp.Models
{
    public partial class CarRoutteType
    {
        public CarRoutteType()
        {
            RoutteCars = new List<RoutteCar>();
        }

        public int CarRoutteTypeId { get; set; }
        public string CarRoutteName { get; set; }

        public virtual List<RoutteCar> RoutteCars { get; set; }
    }
}
