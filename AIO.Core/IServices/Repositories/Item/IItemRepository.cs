using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Item
{
    public interface IItemRepository : IGenericRepository<Entities.Items.Item>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
