using AIO.Core.Entities.SupplierItems;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.SupplierProjectItems;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.SupplierProjectItems
{
    public class SupplierProjectItemRepository : GenericRepository<SupplierProjectItem>, ISupplierProjectItemRepository
    {
        private readonly AIODBContext _db;

        public SupplierProjectItemRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
