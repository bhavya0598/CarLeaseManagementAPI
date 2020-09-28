namespace LeaseManagement.BL.Quote
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LeaseManagement.BusinessEntities.ViewModels;

    public interface IQuoteManager
    {
        Task<List<PaybackTimeVM>> GetPaybackTime();

        Task<List<MileageLimitVM>> GetMileageLimit();

        Task<QuoteVM> SaveQuoteAsync(QuoteVM quote);
    }
}
