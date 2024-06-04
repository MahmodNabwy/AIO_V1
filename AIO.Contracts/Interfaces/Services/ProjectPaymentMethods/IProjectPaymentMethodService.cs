using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Queries;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.ProjectPaymentMethods
{
    public interface IProjectPaymentMethodService
    {
        Task<IHolderOfDTO> SaveAsync(ProjectPaymentMethodAddCommand request);
        Task<IHolderOfDTO> UpdateAsync(ProjectPaymentMethodUpdateCommand request);
        Task<IHolderOfDTO> GetAllAsync(GetAllProjectPaymentMethodsQuery request);
        Task<IHolderOfDTO> DeleteAsync(int Id);

    }
}
