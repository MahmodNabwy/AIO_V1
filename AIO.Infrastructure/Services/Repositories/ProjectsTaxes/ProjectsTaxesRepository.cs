using AIO.Core.Entities.ProjectsTaxes;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.ProjectsTaxes;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectsTaxes
{
    public class ProjectsTaxesRepository : GenericRepository<ProjectTaxe>, IProjectsTaxesRepository
    {
        private readonly AIODBContext _db;

        public ProjectsTaxesRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
