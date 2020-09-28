namespace LeaseManagement.Business
{
    using LeaseManagement.Authentication;
    using LeaseManagement.Authentication.Interfaces;
    using LeaseManagement.BL.Car;
    using LeaseManagement.BL.Interfaces;
    using LeaseManagement.BL.Quote;
    using LeaseManagement.BL.UserDetails;
    using Microsoft.Extensions.DependencyInjection;

    public class IoCConfig
    {
        public static void ConfigContainer(IServiceCollection _services)
        {
            _services.AddScoped<IUserManager, UserManager>();
            _services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            _services.AddScoped<ICarManager, CarManager>();
            _services.AddScoped<IQuoteManager, QuoteManager>();
            _services.AddScoped<IUserManager, UserManager>();
        }
    }
}
