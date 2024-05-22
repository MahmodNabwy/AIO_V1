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
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
