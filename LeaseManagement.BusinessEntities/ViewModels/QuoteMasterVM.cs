namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class QuoteMasterVM
    {
        [Key]
        public Guid QuoteId { get; set; }
        public string Price { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string FuelCapacity { get; set; }
        public string BodyType { get; set; }
        public string CO2Emission { get; set; }
        public string Color { get; set; }
        public string FuelConsumption { get; set; }
        public string ImagePath { get; set; }
        public string InteriorType { get; set; }
        public string Mileage { get; set; }
        public DateTime ModelDate { get; set; }
        public string Seats { get; set; }
        public string Transmission { get; set; }
        public string Email { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string BankAddress { get; set; }
        public string BankBranch { get; set; }
        public string BankCountry { get; set; }
        public string BankName { get; set; }
        public string BankState { get; set; }
        public string AccountType { get; set; }
        public string ContractType { get; set; }
        public string EmploymentType { get; set; }
        public string Kilometers { get; set; }
        public string Months { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
        public string DOB { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string HouseNo { get; set; }
        public string Lastname { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyName { get; set; }
        public string CreditScore { get; set; }
        public string Salary { get; set; }

    }
}
