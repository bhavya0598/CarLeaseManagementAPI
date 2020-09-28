using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.DataEntities.Models;
using LeaseManagement.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Car.Data
{
    public interface ICarRepository : IRepository<CarVM>
    {
        Task<List<CarVM>> GetAllCar();

        Task<CarVM> GetCarById(string id);
    }
}
