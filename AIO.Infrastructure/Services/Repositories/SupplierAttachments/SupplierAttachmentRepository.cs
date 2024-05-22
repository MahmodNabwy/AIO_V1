using AIO.Core.Entities.SupplierAttachmets;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.SupplierAttachments;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.SupplierAttachments
{
    public class SupplierAttachmentRepository : GenericRepository<SupplierAttachment>, ISupplierAttachmentRepository
    {

        private readonly AIODBContext _db;

        public SupplierAttachmentRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
