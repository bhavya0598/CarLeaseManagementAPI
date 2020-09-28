using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblCar
    {
        public TblCar()
        {
            TblQuote = new HashSet<TblQuote>();
        }

        public Guid CarId { get; set; }
        public int MakeId { get; set; }
        public int FuelId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Mileage { get; set; }
        public int TransmissionId { get; set; }
        public bool IsAvailable { get; set; }
        public string Price { get; set; }
        public string Co2emission { get; set; }
        public int BodyTypeId { get; set; }
        public string FuelCapacity { get; set; }
        public DateTime ModelDate { get; set; }
        public byte Seats { get; set; }
        public string FuelComsumption { get; set; }
        public int InteriorTypeId { get; set; }
        public string ImagePath { get; set; }

        public TblBodyType BodyType { get; set; }
        public TblFuel Fuel { get; set; }
        public TblInteriorType InteriorType { get; set; }
        public TblMake Make { get; set; }
        public TblTransmission Transmission { get; set; }
        public ICollection<TblQuote> TblQuote { get; set; }
    }
}
