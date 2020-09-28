using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblFuel
    {
        public TblFuel()
        {
            TblCar = new HashSet<TblCar>();
        }

        public int FuelId { get; set; }
        public string FuelType { get; set; }

        public ICollection<TblCar> TblCar { get; set; }
    }
}
