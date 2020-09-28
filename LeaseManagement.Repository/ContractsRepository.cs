using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class ContractsRepository : Repository<ContractVM>, IContractsRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_GET_CONTRACTS = "sp_GetContracts";
        public ContractsRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ContractVM>> GetContracts()
        {
            return await ExecuteSqlQuery(SP_GET_CONTRACTS);
        }
    }
}
