using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Queries;
using AIO.Contracts.Features.ProjectTaxes.Commands;
using AIO.Contracts.Features.ProjectTaxes.Queries;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.ProjectTaxes
{
    public interface IProjectTaxesService
    {
        Task<IHolderOfDTO> UpdateAsync(ProjectTaxesUpdateCommand request);
        Task<IHolderOfDTO> GetAllAsync(GetAllProjectTaxesQuery request);
    }
}
