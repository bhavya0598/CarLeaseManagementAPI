using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblAccountType
    {
        public TblAccountType()
        {
            TblUserBankDetails = new HashSet<TblUserBankDetails>();
        }

        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }

        public ICollection<TblUserBankDetails> TblUserBankDetails { get; set; }
    }
}
