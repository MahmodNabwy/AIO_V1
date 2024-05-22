using AIO.Core.Entities.Suppliers;
using AIO.Core.IServices.Repositories.Suppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Suppliers
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly AIODBContext _db;
        public SupplierRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }

    }
}
