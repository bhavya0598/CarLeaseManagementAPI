using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class EmploymentTypeRepository : Repository<EmploymentTypeVM>, IEmploymentTypeRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_GET_EMPLOYMENT_TYEPS = "sp_GetEmploymentTypes";

        public EmploymentTypeRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EmploymentTypeVM>> GetEmploymentTypes()
        {
            return await ExecuteSqlQuery(SP_GET_EMPLOYMENT_TYEPS);
        }
    }
}
