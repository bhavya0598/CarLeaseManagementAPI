using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class PaybackTimeRepository : Repository<PaybackTimeVM>, IPaybackTimeRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_GET_PAYBACK_TIME = "sp_GetPaybackTime";

        public PaybackTimeRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PaybackTimeVM>> GetPaybackTime()
        {
            return await ExecuteSqlQuery(SP_GET_PAYBACK_TIME);
        }
    }
}
