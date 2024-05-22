using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.PaymentMethods
{
    public interface IPaymentMethodsRepository : IGenericRepository<PaymentMethod>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);

    }
}
