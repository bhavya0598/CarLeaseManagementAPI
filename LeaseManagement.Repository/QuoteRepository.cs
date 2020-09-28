using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class QuoteRepository : Repository<QuoteVM>, IQuoteRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_SAVE_QUOTE = "sp_SaveQuote @quoteId, @carId, @userId, @paybackTimeId, @mileageLimitId, @price";
        public QuoteRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<QuoteVM> SaveQuoteAsync(QuoteVM quote)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@quoteId", quote.QuoteId ),
                new SqlParameter("@userId",quote.UserId),
                new SqlParameter("@carId", quote.CarId),
                new SqlParameter("@paybackTimeId", quote.PaybackTimeId),
                new SqlParameter("@mileageLimitId", quote.MileageLimitId),
                new SqlParameter("@price", quote.Price)
            };
            return await ExecuteSqlQueryWithParameters(SP_SAVE_QUOTE, parameters);
        }
    }
}
