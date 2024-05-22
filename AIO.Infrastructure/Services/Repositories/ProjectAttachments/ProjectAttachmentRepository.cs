using AIO.Core.Entities.ProjectAttachments;
using AIO.Core.IServices.Repositories.ProjectAttachments;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectAttachments
{
    public class ProjectAttachmentRepository : GenericRepository<ProjectsAttachments>, IProjectAttachmentRepository
    {
        private readonly AIODBContext _db;

        public ProjectAttachmentRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
