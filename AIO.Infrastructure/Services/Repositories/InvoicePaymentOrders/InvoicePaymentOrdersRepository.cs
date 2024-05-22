using AIO.Core.Entities.InvoiceItems;
using AIO.Core.Entities.InvoicePaymentOrders;
using AIO.Core.IServices.Repositories.Invoice_Items;
using AIO.Core.IServices.Repositories.InvoicePaymentOrders;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.InvoicePaymentOrders
{
    public class InvoicePaymentOrdersRepository : GenericRepository<InvoicePaymentOrder>, IInvoicePaymentOrdersRepository
    {
        private readonly AIODBContext _db;

        public InvoicePaymentOrdersRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
