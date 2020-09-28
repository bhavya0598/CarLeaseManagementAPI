using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LeaseManagement.BusinessEntities.ViewModels;

namespace LeaseManagement.Repository.Interfaces
{
    public interface IUserBankRepository
    {
        Task<UserBankVM> AddUserBankData(UserBankVM userbank);

        Task<bool> CheckBankDataIfExist(Guid userId);

        Task<UserBankVM> GetUserBankDataAsync(string userId);
    }
}
