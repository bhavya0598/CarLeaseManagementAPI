using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblBodyType
    {
        public TblBodyType()
        {
            TblCar = new HashSet<TblCar>();
        }

        public int BodyTypeId { get; set; }
        public string BodyType { get; set; }

        public ICollection<TblCar> TblCar { get; set; }
    }
}
