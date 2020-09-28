using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LeaseManagement.BusinessEntities.ViewModels;

namespace LeaseManagement.Repository.Interfaces
{
    public interface IUserPersonalRepository
    {
        Task<UserPersonalVM> AddUserPersonalData(UserPersonalVM userPersonal);

        Task<bool> CheckPersonalDataIfExist(Guid userId);

        Task<UserPersonalVM> GetUserPersonalAsync(string userId);
    }
}
