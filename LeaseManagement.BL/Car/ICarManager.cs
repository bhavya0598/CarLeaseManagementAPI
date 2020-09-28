namespace LeaseManagement.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LeaseManagement.BusinessEntities.ViewModels;

    public interface ICarManager
    {
        Task<List<CarVM>> GetAll();

        Task<CarVM> GetElementById(string id);
    }
}
