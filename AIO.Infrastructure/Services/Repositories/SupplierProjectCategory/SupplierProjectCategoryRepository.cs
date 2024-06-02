using AIO.Core.Entities.SupplierCategories;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.SupplierCategories;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.SupplierCategories
{
    public class SupplierProjectCategoryRepository : GenericRepository<SupplierProjectCategory>, ISupplierProjectCategoryRepository
    {
        private readonly AIODBContext _db;

        public SupplierProjectCategoryRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
