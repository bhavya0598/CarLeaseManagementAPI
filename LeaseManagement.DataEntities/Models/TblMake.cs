using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblMake
    {
        public TblMake()
        {
            TblCar = new HashSet<TblCar>();
        }

        public int MakeId { get; set; }
        public string Make { get; set; }

        public ICollection<TblCar> TblCar { get; set; }
    }
}
