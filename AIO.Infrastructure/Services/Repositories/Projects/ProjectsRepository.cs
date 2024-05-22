using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
using AIO.Core.IServices.Repositories.Owners;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Projects
{
    public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
    {
        private readonly AIODBContext _db;

        public ProjectsRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
