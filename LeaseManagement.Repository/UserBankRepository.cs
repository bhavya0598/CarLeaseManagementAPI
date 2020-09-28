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
    public class UserBankRepository : Repository<UserBankVM>, IUserBankRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_ADD_USER_BANK_DATA = "sp_AddUserBankData @accountNumber, @accountHolderName, @accountTypeId, @bankAddress, @bankBranch, @bankCountry, @bankName, @bankState, @userId";
        private const string SP_GET_USER_BANK_DATA = "sp_GetUserBankData @id";

        public UserBankRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserBankVM> AddUserBankData(UserBankVM userbank)
        {
            var parameters = new List<SqlParameter>()
            {
            new SqlParameter("@accountNumber", userbank.AccountNumber),
            new SqlParameter("@accountHolderName", userbank.AccountHolderName),
            new SqlParameter("@accountTypeId", userbank.AccountTypeId),
            new SqlParameter("@bankAddress", userbank.BankAddress),
            new SqlParameter("@bankBranch", userbank.BankBranch),
            new SqlParameter("@bankCountry", userbank.BankCountry),
            new SqlParameter("@bankName", userbank.BankName),
            new SqlParameter("@bankState", userbank.BankState),
            new SqlParameter("@userId", userbank.UserId),
            };
            return await ExecuteSqlQueryWithParameters(SP_ADD_USER_BANK_DATA, parameters);
        }

        public async Task<bool> CheckBankDataIfExist(Guid userId)
        {
            var parameter = new SqlParameter("@id", userId);         
            return await ExecuteNonQuery(SP_GET_USER_BANK_DATA, parameter);
        }

        public async Task<UserBankVM> GetUserBankDataAsync(string userId)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id", userId)
            };
            return await ExecuteSqlQueryWithParameters(SP_GET_USER_BANK_DATA, parameters);
        }
    }
}
