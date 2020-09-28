using LeaseManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public interface IUserAuthenticationRepository : IRepository<UserVM>
    {
        Task<UserVM> GetUser(string email, string password);

        Task<UserVM> AddUser(UserVM newUser);

        Task<ErrorMessageVM> CheckDuplicate(string username, string email);
        Task<UserVM> CheckActivationCode(string activationCode);
    }
}
