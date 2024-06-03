using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Contracts.DTOs.Getter.ProjectSupplier;
using AIO.Contracts.Features.Projects.Queries;
using AIO.Contracts.Filters;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Projects
{
    public interface IProjectsRepository : IGenericRepository<Project>
    {
        IQueryable<ProjectsDataGetterDTO> buildFilterQuery(ProjectFilter filter);
        IQueryable<ProjectsDataGetterDTO> GetAll();
        Task<List<ProjectDateGetterByIdDTO>> GetByIdAsync(GetProjectByIdQuery request);

    }
}
