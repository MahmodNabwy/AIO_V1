using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.ProjectSuppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.ProjectSuppliers
{
    public interface IProjectSupplierRepository : IGenericRepository<ProjectSupplier>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
