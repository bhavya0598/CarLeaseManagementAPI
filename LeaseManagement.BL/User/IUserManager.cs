namespace LeaseManagement.BL.UserDetails
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using LeaseManagement.BusinessEntities.ViewModels;

    public interface IUserManager
    {
        Task<UserPersonalVM> AddUserPersonalDataAsync(UserPersonalVM userPersonal);

        Task<List<AccountTypeVM>> GetAccountTypesAsync();

        Task<UserBankVM> AddUserBankData(UserBankVM userbank);

        Task<UserEmploymentVM> AddUserEmploymentDataAsync(UserEmploymentVM userEmployment);

        Task<List<ContractVM>> GetContractsAsync();

        Task<List<EmploymentTypeVM>> GetEmploymentTypesAsync();

        Task<UserPersonalVM> GetUserPerosnalAsync(string userId);

        Task<UserBankVM> GetUserBankDataAsync(string userId);

        Task<UserEmploymentVM> GetUserEmploymentDataAsync(string userId);

        string GetUserId(ClaimsIdentity identity);
    }
}
