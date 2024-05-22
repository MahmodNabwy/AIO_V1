using AIO.Core.Entities.ProjectSupplierAttachments;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.ProjectSupplierAttachments;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectSupplierAttachments
{
    public class ProjectSupplierAttachmentRepository : GenericRepository<ProjectSupplierAttachment>, IProjectSupplierAttachmentRepository
    {
        private readonly AIODBContext _db;

        public ProjectSupplierAttachmentRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
