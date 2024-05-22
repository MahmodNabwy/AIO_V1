using AIO.Contracts.Filters;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Suppliers
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
