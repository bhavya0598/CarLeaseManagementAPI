using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblMileageLimit
    {
        public TblMileageLimit()
        {
            TblQuote = new HashSet<TblQuote>();
        }

        public int MileageLimitId { get; set; }
        public string Kilometers { get; set; }

        public ICollection<TblQuote> TblQuote { get; set; }
    }
}
