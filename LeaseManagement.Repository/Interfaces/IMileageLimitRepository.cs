using LeaseManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository.Interfaces
{
    public interface IMileageLimitRepository
    {
        Task<List<MileageLimitVM>> GetMileageLimit();

    }
}
