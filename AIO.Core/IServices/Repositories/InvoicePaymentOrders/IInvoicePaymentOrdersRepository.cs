using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.InvoicePaymentOrders;
using AIO.Core.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.InvoicePaymentOrders
{
    public interface IInvoicePaymentOrdersRepository : IGenericRepository<InvoicePaymentOrder>
    {
    }
}
