using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository;
using Microsoft.EntityFrameworkCore;

namespace LeaseManagement.Car.Data
{
    public class CarRepository : Repository<CarVM>, ICarRepository
    {
        private readonly LeaseManagementDbContext _context;
        private bool disposed = false;
        private const string SP_GET_ALL_CARS = "sp_GetAllCars";
        private const string SP_GET_CAR_BY_ID = "sp_GetCarById @id";
        private const string SP_GET_PAYBACKTIME_AND_MILEAGE = "sp_GetPaybackTimeAndMileageLimit";
        private const string SP_GET_BODY_TYPES = "sp_GetBodyTypes";

        public CarRepository(LeaseManagementDbContext context):base(context)
        {
            _context = context;
        }

        #region Get All Car
        public async Task<List<CarVM>> GetAllCar() => await ExecuteSqlQuery(SP_GET_ALL_CARS);
        #endregion

        #region Get Car by Id
        public async Task<CarVM> GetCarById(string id)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id", id)
            };
            return await ExecuteSqlQueryWithParameters(SP_GET_CAR_BY_ID, parameters);
        }
        #endregion

        #region Dipose
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Save
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
