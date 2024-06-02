using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Features.ProjectsSuppliers.Commands;
using AIO.Contracts.Features.ProjectsSuppliers.Queries;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.ProjectSupplier
{
    public interface IProjectSupplierService
    {
        Task<IHolderOfDTO> SaveAsync(ProjectSupplierAddCommand setterDTO);
        Task<IHolderOfDTO> GetAllAsync(GetProjectSuppliersQuery request);


    }
}
