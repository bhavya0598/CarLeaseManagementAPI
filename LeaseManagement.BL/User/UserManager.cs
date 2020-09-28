namespace LeaseManagement.BL.UserDetails
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using LeaseManagement.BusinessEntities.ViewModels;
    using LeaseManagement.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class UserManager : IUserManager
    {
        IUnitOfWork _uow;

        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UserBankVM> AddUserBankData(UserBankVM userbank)
        {
            var response = await _uow.UserBankRepository.CheckBankDataIfExist(userbank.UserId);
            if (!response)
                return await _uow.UserBankRepository.AddUserBankData(userbank);
            return userbank;
        }

        public async Task<UserEmploymentVM> AddUserEmploymentDataAsync(UserEmploymentVM userEmployment)
        {
            var response = await _uow.UserEmploymentRepository.CheckEmploymentDataIfExist(userEmployment.UserId);
            if (!response)
                return await _uow.UserEmploymentRepository.AddUserEmploymentData(userEmployment);
            return userEmployment;
        }

        public async Task<UserPersonalVM> AddUserPersonalDataAsync(UserPersonalVM userPersonal)
        {
            var response = await _uow.UserPersonalRepository.CheckPersonalDataIfExist(userPersonal.UserId);
            if (!response)
                return await _uow.UserPersonalRepository.AddUserPersonalData(userPersonal);
            return userPersonal;
        }

        public async Task<List<AccountTypeVM>> GetAccountTypesAsync() => await _uow.AccountTypeRepository.GetAccountTypes();

        public async Task<List<ContractVM>> GetContractsAsync() => await _uow.ContractsRepository.GetContracts();

        public async Task<List<EmploymentTypeVM>> GetEmploymentTypesAsync() => await _uow.EmploymentTypeRepository.GetEmploymentTypes();

        public async Task<UserBankVM> GetUserBankDataAsync(string userId) => await _uow.UserBankRepository.GetUserBankDataAsync(userId);

        public async Task<UserEmploymentVM> GetUserEmploymentDataAsync(string userId) => await _uow.UserEmploymentRepository.GetUserEmploymentDataAsync(userId);

        public string GetUserId(ClaimsIdentity identity) => identity.FindFirst("UserId").Value;

        public async Task<UserPersonalVM> GetUserPerosnalAsync(string userId) => await _uow.UserPersonalRepository.GetUserPersonalAsync(userId);
    }
}
