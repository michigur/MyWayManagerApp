using System;
using System.Collections.Generic;



namespace MyWayManagerApp.Models
{
    public partial class CarType
    {
        public CarType()
        {
            Cars = new List<Car>();
        }

        public int CarTypeId { get; set; }
        public string CarTypeName { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
