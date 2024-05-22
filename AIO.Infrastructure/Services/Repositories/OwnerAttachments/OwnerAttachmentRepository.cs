using AIO.Core.Entities.OwnerAttachments;
using AIO.Core.IServices.Repositories.OwnerAttachments;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.OwnerAttachments
{
    public class OwnerAttachmentRepository : GenericRepository<OwnerAttachment>, IOwnerAttachmentRepository
    {
        private readonly AIODBContext _db;

        public OwnerAttachmentRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
