using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblInteriorType
    {
        public TblInteriorType()
        {
            TblCar = new HashSet<TblCar>();
        }

        public int InteriorTypeId { get; set; }
        public string InteriorType { get; set; }

        public ICollection<TblCar> TblCar { get; set; }
    }
}
