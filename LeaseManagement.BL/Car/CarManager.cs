namespace LeaseManagement.BL.Car
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LeaseManagement.BL.Interfaces;
    using LeaseManagement.BusinessEntities.ViewModels;
    using LeaseManagement.Infrastructure;

    public class CarManager : ICarManager
    {
        IUnitOfWork _uow;
        public CarManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<CarVM>> GetAll() => await _uow.CarRepository.GetAllCar();

        public async Task<CarVM> GetElementById(string id) => await _uow.CarRepository.GetCarById(id);
    }
}
