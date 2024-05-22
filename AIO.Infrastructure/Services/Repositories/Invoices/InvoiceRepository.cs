using AIO.Core.Entities.InvoiceItems;
using AIO.Core.Entities.Invoices;
using AIO.Core.IServices.Repositories.Invoice_Items;
using AIO.Core.IServices.Repositories.Invoices;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Invoices
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        private readonly AIODBContext _db;
        public InvoiceRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
