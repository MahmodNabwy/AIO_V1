using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Categories
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
