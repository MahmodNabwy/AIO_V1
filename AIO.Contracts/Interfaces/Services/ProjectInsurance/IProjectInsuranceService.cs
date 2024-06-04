using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.ProjectInsurance
{
    public interface IProjectInsuranceService
    {
        Task<IHolderOfDTO> SaveAsync(ProjectInsurancesAddCommand request);
        Task<IHolderOfDTO> UpdateAsync(ProjectInsurancesUpdateCommand request);
        Task<IHolderOfDTO> GetAllAsync(GetAllProjectInsurancesQuery request);
        Task<IHolderOfDTO> DeleteAsync(int Id);

    }
}
