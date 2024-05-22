using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
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
        Task<IHolderOfDTO> AddNewProjectPaymentMethod(int projectId, ProjectPaymentMethodSetterDTO setterDTO);

    }
}
