using AIO.Core.Entities.ProjectSuppliers;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.ProjectSuppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectSuppliers
{
    public class ProjectSupplierRepository : GenericRepository<ProjectSupplier>, IProjectSupplierRepository
    {
        private readonly AIODBContext _db;
        public ProjectSupplierRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
