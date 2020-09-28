using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblQuote
    {
        public Guid QuoteId { get; set; }
        public Guid UserId { get; set; }
        public int PaybackTimeId { get; set; }
        public int MileageLimitId { get; set; }
        public Guid CarId { get; set; }
        public string Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CretaedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public TblCar Car { get; set; }
        public TblMileageLimit MileageLimit { get; set; }
        public TblPaybackTime PaybackTime { get; set; }
        public TblUser User { get; set; }
    }
}
