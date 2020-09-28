namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class MileageLimitVM
    {
        [Key]
        public int MileageLimitId { get; set; }
        public string Kilometers { get; set; }
    }
}
