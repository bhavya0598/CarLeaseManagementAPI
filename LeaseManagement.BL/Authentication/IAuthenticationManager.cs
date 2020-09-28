namespace LeaseManagement.Authentication.Interfaces
{
    using System.Threading.Tasks;
    using LeaseManagement.BusinessEntities.ViewModels;

    public interface IAuthenticationManager
    {
        Task<UserVM> Authenticate(string email, string password);

        string BuildToken(UserVM user);

        Task<ErrorMessageVM> RegisterNewUser(UserVM newUser);

        Task<bool> VerificationLink(UserVM newUser);

        Task<bool> CheckVerification(string ActivationCode);
    }
}
