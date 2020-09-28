using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LeaseManagement.BusinessEntities.ViewModels;

namespace LeaseManagement.Repository.Interfaces
{
    public interface IUserEmploymentRepository
    {
        Task<UserEmploymentVM> AddUserEmploymentData(UserEmploymentVM userEmployment);

        Task<bool> CheckEmploymentDataIfExist(Guid userId);

        Task<UserEmploymentVM> GetUserEmploymentDataAsync(string userId);
    }
}
