namespace LeaseManagement.BL.Quote
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LeaseManagement.BusinessEntities.ViewModels;
    using LeaseManagement.Infrastructure;
    public class QuoteManager : IQuoteManager
    {
        IUnitOfWork _uow;
        public QuoteManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<MileageLimitVM>> GetMileageLimit() => await _uow.MileageLimitRepository.GetMileageLimit();

        public async Task<List<PaybackTimeVM>> GetPaybackTime() => await _uow.PaybackTimeRepository.GetPaybackTime();

        public async Task<QuoteVM> SaveQuoteAsync(QuoteVM quote) => await _uow.QuoteRepository.SaveQuoteAsync(quote);
    }
}
