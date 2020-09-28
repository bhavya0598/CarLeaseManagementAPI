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
    public class UserEmploymentRepository : Repository<UserEmploymentVM>, IUserEmploymentRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_ADD_USER_EMPLOYMENT_DATA = "sp_AddUserEmploymentData @userId, @companyAddress, @companyName, @contractId, @creditScore, @employmentTypeId, @salary";
        private const string SP_GET_USER_EMPLOYMENT_DATA = "sp_GetUserEmploymentData @id";

        public UserEmploymentRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserEmploymentVM> AddUserEmploymentData(UserEmploymentVM userEmployment)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@userId", userEmployment.UserId),
                new SqlParameter("@companyAddress", userEmployment.CompanyAddress),
                new SqlParameter("@companyName", userEmployment.CompanyName),
                new SqlParameter("@contractId", userEmployment.ContractId),
                new SqlParameter("@creditScore", userEmployment.CreditScore),
                new SqlParameter("@employmentTypeId", userEmployment.EmploymentTypeId),
                new SqlParameter("@salary", userEmployment.Salary),
            };
            return await ExecuteSqlQueryWithParameters(SP_ADD_USER_EMPLOYMENT_DATA, parameters);
        }

        public async Task<bool> CheckEmploymentDataIfExist(Guid userId)
        {
            var parameters = new SqlParameter("@id", userId);
            return await ExecuteNonQuery(SP_GET_USER_EMPLOYMENT_DATA, parameters);
        }

        public async Task<UserEmploymentVM> GetUserEmploymentDataAsync(string userId)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id", userId)
            };
            return await ExecuteSqlQueryWithParameters(SP_GET_USER_EMPLOYMENT_DATA, parameters);
        }
    }
}
