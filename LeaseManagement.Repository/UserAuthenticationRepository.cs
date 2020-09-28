using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class UserAuthenticationRepository : Repository<UserVM>, IUserAuthenticationRepository
    {
        LeaseManagementDbContext _context;
        private bool disposed = false;

        private const string SP_GET_USER_WITH_VALID_CREDENTIAL = "sp_GetUserWithValidCredential @email, @password";
        private const string SP_REGISTER_NEW_USER = "sp_RegisterNewUser @email, @password, @username, @activationCode, @isVerified";
        private const string SP_GET_ALL_USERS = "sp_GetAllUsers";
        private const string SP_GET_USER_WITH_MATCHING_CODE = "sp_GetUserWithMatchingCode @activationCode";

        public UserAuthenticationRepository(LeaseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Save
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Get User
        public async Task<UserVM> GetUser(string email, string password)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@email", email),
                new SqlParameter("@password", password)
            };
            //var parameters = this.AddParameters(new { email = email }, new { password = password });
            return await ExecuteSqlQueryWithParameters(SP_GET_USER_WITH_VALID_CREDENTIAL, parameters);
        }
        #endregion

        #region Add User
        public async Task<UserVM> AddUser(UserVM newUser)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@email", newUser.Email),
                new SqlParameter("@password", newUser.Password),
                new SqlParameter("@username", newUser.Username),
                new SqlParameter("@activationCode", newUser.ActivationCode),
                new SqlParameter("@isVerified", newUser.IsVerified)
            };
            //var email = newUser.Email;
            //var password = newUser.Password;
            //var username = newUser.Username;
            //var parameters = this.AddParameters(email, password, username);
            return await ExecuteSqlQueryWithParameters(SP_REGISTER_NEW_USER, parameters);
        }
        #endregion

        #region Check Duplicate
        public async Task<ErrorMessageVM> CheckDuplicate(string username, string email)
        {
            var users = await ExecuteSqlQuery(SP_GET_ALL_USERS);
            foreach (var user in users)
            {
                if (user.Username == username )
                    return new ErrorMessageVM() { Message = "Username Exists!" };
                if (user.Email == email)
                    return new ErrorMessageVM() { Message = "Email Exists!" };
            }
            return null;
        }
        #endregion

        #region Check Activation Code
        public async Task<UserVM> CheckActivationCode(string activationCode)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@activationCode", activationCode),
            };
            return await ExecuteSqlQueryWithParameters(SP_GET_USER_WITH_MATCHING_CODE, parameters);
        }
        #endregion

        //private List<SqlParameter> AddParameters(params dynamic[] param)
        //{
        //    var parameters = new List<SqlParameter>();
        //    for (int i = 0; i < param.Length; i++)
        //    {
        //        parameters.Add(new SqlParameter($"@{param}", param[i]));
        //    }
        //    return parameters;
        //}
    }
}
 