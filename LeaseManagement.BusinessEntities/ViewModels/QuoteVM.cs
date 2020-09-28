namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class QuoteVM
    {
        [Key]
        public Guid QuoteId { get; set; }

        public Guid UserId { get; set; }

        public Guid CarId { get; set; }

        public int PaybackTimeId { get; set; }

        public int MileageLimitId { get; set; }

        public string Price { get; set; }
    }
}
