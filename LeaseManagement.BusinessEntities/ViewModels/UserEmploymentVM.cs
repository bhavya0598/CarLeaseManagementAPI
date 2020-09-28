namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class UserEmploymentVM
    {
        [Key]
        public int UserEmploymentId { get; set; }
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Salary { get; set; }
        public string CreditScore { get; set; }
        public int ContractId { get; set; }
        public int EmploymentTypeId { get; set; }
        public string EmploymentType { get; set; }
        public string ContractType { get; set; }
    }
}
