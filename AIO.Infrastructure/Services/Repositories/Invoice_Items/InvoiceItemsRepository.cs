using AIO.Core.Entities.InvoiceItems;
using AIO.Core.Entities.Items;
using AIO.Core.IServices.Repositories.Invoice_Items;
using AIO.Core.IServices.Repositories.Item;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Invoice_Items
{
    public class InvoiceItemsRepository : GenericRepository<InvoiceItems>, IInvoiceItemsRepository
    {
        private readonly AIODBContext _db;
        public InvoiceItemsRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
