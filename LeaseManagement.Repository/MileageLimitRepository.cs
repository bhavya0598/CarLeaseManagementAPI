using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class MileageLimitRepository : Repository<MileageLimitVM>, IMileageLimitRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_GET_MILEAGE_LIMIT = "sp_GetMileageLimit";

        public MileageLimitRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MileageLimitVM>> GetMileageLimit() => await ExecuteSqlQuery(SP_GET_MILEAGE_LIMIT);
    }
}
