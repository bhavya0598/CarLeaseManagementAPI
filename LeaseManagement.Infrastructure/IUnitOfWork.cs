namespace LeaseManagement.Infrastructure
{
    using System;
    using System.Threading.Tasks;
    using LeaseManagement.Car.Data;
    using LeaseManagement.Repository;
    using LeaseManagement.Repository.Interfaces;

    public interface IUnitOfWork : IDisposable
    {
        ICarRepository CarRepository { get; }

        IUserAuthenticationRepository UserAuthenticationRepository { get; }

        IMileageLimitRepository MileageLimitRepository { get; }

        IPaybackTimeRepository PaybackTimeRepository { get; }

        IUserPersonalRepository UserPersonalRepository { get; }

        IAccountTypeRepository AccountTypeRepository { get; }

        IUserBankRepository UserBankRepository { get; }

        IUserEmploymentRepository UserEmploymentRepository { get; }

        IContractsRepository ContractsRepository { get; }

        IEmploymentTypeRepository EmploymentTypeRepository { get; }

        IQuoteRepository QuoteRepository { get; }

        Task<int> Save();
    }
}
