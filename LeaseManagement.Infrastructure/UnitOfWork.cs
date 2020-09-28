namespace LeaseManagement.Infrastructure
{
    using System.Threading.Tasks;
    using LeaseManagement.Car.Data;
    using LeaseManagement.DataEntities.Models;
    using LeaseManagement.Repository;
    using LeaseManagement.Repository.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        private LeaseManagementDbContext _context;

        public UnitOfWork(LeaseManagementDbContext _context)
        {
            this._context = _context;
        }

        #region Car Repository
        public ICarRepository CarRepository
        {
            get
            {
                return new CarRepository(_context);
            }
        }
        #endregion

        #region User Authentication Repository
        public IUserAuthenticationRepository UserAuthenticationRepository
        {
            get
            {
                return new UserAuthenticationRepository(_context);
            }
        }
        #endregion

        #region Mileage Repository
        public IMileageLimitRepository MileageLimitRepository
        {
            get
            {
                return new MileageLimitRepository(_context);

            }
        }
        #endregion

        #region PaybackTime Repository
        public IPaybackTimeRepository PaybackTimeRepository
        {
            get
            {
                return new PaybackTimeRepository(_context);

            }
        }
        #endregion

        #region User Personal Repository
        public IUserPersonalRepository UserPersonalRepository
        {
            get
            {
                return new UserPersonalRepository(_context);
            }

        }
        #endregion

        #region Account Type Repository
        public IAccountTypeRepository AccountTypeRepository
        {
            get
            {
                return new AccountTypeRepository(_context);
            }
        }
        #endregion

        #region User Bank Repository
        public IUserBankRepository UserBankRepository
        {
            get
            {
                return new UserBankRepository(_context);
            }

        }
        #endregion

        #region User Employment Repository
        public IUserEmploymentRepository UserEmploymentRepository
        {
            get
            {
                return new UserEmploymentRepository(_context);
            }
        }
        #endregion

        #region Contracts Repository
        public IContractsRepository ContractsRepository
        {
            get
            {
                return new ContractsRepository(_context);
            }
        }
        #endregion

        #region Employment Type Repository
        public IEmploymentTypeRepository EmploymentTypeRepository
        {
            get
            {
                return new EmploymentTypeRepository(_context);
            }
        }
        #endregion

        #region Quote Repository
        public IQuoteRepository QuoteRepository
        {
            get
            {
                return new QuoteRepository(_context);
            }
        }
        #endregion

        #region Save
        public async Task<int> Save()
        {
           return await _context.SaveChangesAsync();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
