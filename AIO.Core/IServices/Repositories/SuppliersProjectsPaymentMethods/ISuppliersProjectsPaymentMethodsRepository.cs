using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.SupplierPaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.SupplierPaymentMethods
{
    public interface ISuppliersProjectsPaymentMethodsRepository : IGenericRepository<SupplierProjectPaymentMethod>
    {
    }
}
