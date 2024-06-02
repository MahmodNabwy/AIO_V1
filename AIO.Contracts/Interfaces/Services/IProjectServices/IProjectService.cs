using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.DTOs.Setter.Projects;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Features.Projects.Queries;
using AIO.Contracts.Features.ProjectsSuppliers.Queries;
using AIO.Contracts.Filters;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.IProjectServices
{
    public interface IProjectService
    {
        Task<IHolderOfDTO> AddNewProject(ProjectAddCommand setterDTO);
        Task<IHolderOfDTO> GetAllAsync(GetAllProjectsQuery request);

        Task<IHolderOfDTO> SearchAsync(GetProjectsSearchQuery filter);

    }
}
