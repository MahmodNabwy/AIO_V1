using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Owners
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
