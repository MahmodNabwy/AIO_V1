using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.InvoiceItems;
using AIO.Core.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Invoice_Items
{
    public interface IInvoiceItemsRepository : IGenericRepository<InvoiceItems>
    {
    }
}
