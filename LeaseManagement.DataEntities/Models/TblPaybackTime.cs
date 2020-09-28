using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblPaybackTime
    {
        public TblPaybackTime()
        {
            TblQuote = new HashSet<TblQuote>();
        }

        public int PaybackTimeId { get; set; }
        public string Months { get; set; }

        public ICollection<TblQuote> TblQuote { get; set; }
    }
}
