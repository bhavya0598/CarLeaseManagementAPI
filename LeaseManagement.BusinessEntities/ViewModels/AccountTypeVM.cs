namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AccountTypeVM
    {
        [Key]
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
    }
}
