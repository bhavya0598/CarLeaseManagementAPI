using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblContractType
    {
        public TblContractType()
        {
            TblUserEmploymentDetails = new HashSet<TblUserEmploymentDetails>();
        }

        public int ContractId { get; set; }
        public string ContractType { get; set; }

        public ICollection<TblUserEmploymentDetails> TblUserEmploymentDetails { get; set; }
    }
}
