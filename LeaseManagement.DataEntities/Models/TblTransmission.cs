using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblTransmission
    {
        public TblTransmission()
        {
            TblCar = new HashSet<TblCar>();
        }

        public int TransmissionId { get; set; }
        public string Transmission { get; set; }

        public ICollection<TblCar> TblCar { get; set; }
    }
}
