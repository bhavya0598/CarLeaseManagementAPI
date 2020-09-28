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
    public class UserPersonalRepository : Repository<UserPersonalVM>, IUserPersonalRepository
    {
        private readonly LeaseManagementDbContext _context;
        private const string SP_ADD_USER_PERSONAL_DATA = "sp_AddUserPersonalData @userId, @firstname, @lastname, @gender, @contact, @dob, @houseNo, @street, @city, @state, @country, @pincode";
        private const string SP_GET_USER_PERSONAL_DATA = "sp_GetUserPersonalData @id";

        public UserPersonalRepository(LeaseManagementDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<UserPersonalVM> AddUserPersonalData(UserPersonalVM userPersonal)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@userId", userPersonal.UserId),
                new SqlParameter("@firstname",userPersonal.Firstname),
                new SqlParameter("@lastname",userPersonal.Lastname),
                new SqlParameter("@gender",userPersonal.Gender),
                new SqlParameter("@contact",userPersonal.Contact),
                new SqlParameter("@dob",userPersonal.Dob),
                new SqlParameter("@houseNo", userPersonal.HouseNo),
                new SqlParameter("@street",userPersonal.Street),
                new SqlParameter("@city",userPersonal.City),
                new SqlParameter("@state",userPersonal.State),
                new SqlParameter("@country",userPersonal.Country),
                new SqlParameter("@pincode", userPersonal.Pincode)
            };
            return await ExecuteSqlQueryWithParameters(SP_ADD_USER_PERSONAL_DATA, parameters);
        }

        public async Task<bool> CheckPersonalDataIfExist(Guid userId)
        {
            var parameter = new SqlParameter("@id", userId);
            return await ExecuteNonQuery(SP_GET_USER_PERSONAL_DATA, parameter);
        }

        public async Task<UserPersonalVM> GetUserPersonalAsync(string userId)
        {
            var parameter = new List<SqlParameter>()
            {
                new SqlParameter("@id",userId)
            };
            return await ExecuteSqlQueryWithParameters(SP_GET_USER_PERSONAL_DATA, parameter);
        }
    }
}
