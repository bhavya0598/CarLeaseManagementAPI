namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ContractVM
    {
        [Key]
        public int ContractId { get; set; }
        public string ContractType { get; set; }
    }
}
