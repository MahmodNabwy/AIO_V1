using AIO.Core.Entities.Attachments;
using AIO.Core.Entities.InvoiceItems;
using AIO.Core.IServices.Repositories.Attachments;
using AIO.Core.IServices.Repositories.Invoice_Items;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Attachments
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        private readonly AIODBContext _db;

        public AttachmentRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
