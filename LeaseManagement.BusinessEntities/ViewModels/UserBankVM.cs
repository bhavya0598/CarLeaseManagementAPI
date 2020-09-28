namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserBankVM
    {
        [Key]
        public int UserBankId { get; set; }
        public Guid UserId { get; set; }
        public string AccountNumber { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankState { get; set; }
        public string BankCountry { get; set; }
        public string BankAddress { get; set; }
    }
}
