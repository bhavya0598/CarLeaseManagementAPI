using System;
using System.Collections.Generic;

namespace LeaseManagement.DataEntities.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblQuote = new HashSet<TblQuote>();
            TblUserBankDetails = new HashSet<TblUserBankDetails>();
            TblUserEmploymentDetails = new HashSet<TblUserEmploymentDetails>();
            TblUserPersonalDetails = new HashSet<TblUserPersonalDetails>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string ActivationCode { get; set; }

        public ICollection<TblQuote> TblQuote { get; set; }
        public ICollection<TblUserBankDetails> TblUserBankDetails { get; set; }
        public ICollection<TblUserEmploymentDetails> TblUserEmploymentDetails { get; set; }
        public ICollection<TblUserPersonalDetails> TblUserPersonalDetails { get; set; }
    }
}
