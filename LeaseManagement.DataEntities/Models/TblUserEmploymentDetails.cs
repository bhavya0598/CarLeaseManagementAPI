using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblUserEmploymentDetails
    {
        public int UserEmploymentId { get; set; }
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Salary { get; set; }
        public string CreditScore { get; set; }
        public int ContractId { get; set; }
        public int EmploymentTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public TblContractType Contract { get; set; }
        public TblEmploymentType EmploymentType { get; set; }
        public TblUser User { get; set; }
    }
}
