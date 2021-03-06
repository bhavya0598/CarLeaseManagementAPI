﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LeaseManagement.BusinessEntities.ViewModels;

namespace LeaseManagement.Repository.Interfaces
{
    public interface IContractsRepository
    {
        Task<List<ContractVM>> GetContracts();
    }
}
