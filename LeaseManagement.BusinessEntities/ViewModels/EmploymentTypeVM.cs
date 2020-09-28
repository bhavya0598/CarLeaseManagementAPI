namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EmploymentTypeVM
    {
        [Key]
        public int EmploymentTypeId { get; set; }
        public string EmploymentType { get; set; }
    }
}
