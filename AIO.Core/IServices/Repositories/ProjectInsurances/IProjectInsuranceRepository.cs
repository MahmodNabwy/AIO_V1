﻿using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.ProjectInsurances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.ProjectInsurances
{
    public interface IProjectInsuranceRepository : IGenericRepository<ProjectInsurance>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);
        Task<List<ProjectInsurancesDataGetterDTO>> GetListAsync(int projectId);
       
    }
}
