namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarVM
    {
        [Key]
        public Guid CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Mileage { get; set; }
        public string Price { get; set; }
        public string CO2Emission { get; set; }
        public string FuelCapacity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModelDate { get; set; }
        public byte Seats { get; set; }
        public string FuelComsumption { get; set; }
        public string Transmission { get; set; }
        public string InteriorType { get; set; }
        public string BodyType { get; set; }
        public string FuelType { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
    }
}
