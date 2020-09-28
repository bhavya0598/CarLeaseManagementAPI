using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblUserBankDetails
    {
        public int UserBankId { get; set; }
        public Guid UserId { get; set; }
        public string AccountNumber { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankState { get; set; }
        public string BankCountry { get; set; }
        public string BankAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public TblAccountType AccountType { get; set; }
        public TblUser User { get; set; }
    }
}
