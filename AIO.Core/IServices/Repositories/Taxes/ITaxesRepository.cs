using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Taxes
{
    public interface ITaxesRepository : IGenericRepository<Taxe>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
