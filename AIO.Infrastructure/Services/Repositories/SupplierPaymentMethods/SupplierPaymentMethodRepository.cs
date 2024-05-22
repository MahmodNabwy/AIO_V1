using AIO.Core.Entities.SupplierPaymentMethods;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.SupplierPaymentMethods;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.SupplierPaymentMethods
{
    public class SupplierPaymentMethodRepository : GenericRepository<SupplierPaymentMethod>, ISupplierPaymentMethodRepository
    {
        private readonly AIODBContext _db;
        public SupplierPaymentMethodRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
