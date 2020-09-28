using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblEmploymentType
    {
        public TblEmploymentType()
        {
            TblUserEmploymentDetails = new HashSet<TblUserEmploymentDetails>();
        }

        public int EmploymentTypeId { get; set; }
        public string EmploymentType { get; set; }

        public ICollection<TblUserEmploymentDetails> TblUserEmploymentDetails { get; set; }
    }
}
