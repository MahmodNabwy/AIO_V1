using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.ProjectsTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.ProjectsTaxes
{
    public interface IProjectsTaxesRepository : IGenericRepository<ProjectTaxe>
    {
        Task<List<ProjectTaxesGetterDTO>> GetListAsync(int projectId);

    }
}
