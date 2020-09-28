namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PaybackTimeVM
    {
        [Key]
        public int PaybackTimeId { get; set; }
        public string Months { get; set; }
    }
}
