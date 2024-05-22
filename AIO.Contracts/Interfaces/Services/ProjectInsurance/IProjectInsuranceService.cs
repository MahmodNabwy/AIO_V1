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
        Task<IHolderOfDTO> AddNewProjectInsurance(int projectId,int insuranceId);

    }
}
