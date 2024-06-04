using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.ProjectPaymentMethods
{
    public interface IProjectPaymentMethodRepository : IGenericRepository<ProjectPaymentMethod>
    {
        Task<List<ProjectPaymentMethodGetterDTO>> GetListAsync(int projectId);

    }
}
