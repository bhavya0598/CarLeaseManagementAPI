using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class AccountTypeRepository : Repository<AccountTypeVM>, IAccountTypeRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_GET_ACCOUNT_TYPES = "sp_GetAccountTypes";
        public AccountTypeRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AccountTypeVM>> GetAccountTypes()
        {
            return await ExecuteSqlQuery(SP_GET_ACCOUNT_TYPES);
        }
    }
}
