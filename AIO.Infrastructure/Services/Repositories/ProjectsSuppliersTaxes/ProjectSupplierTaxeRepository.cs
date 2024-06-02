using AIO.Core.Entities.ProjectsSuppliersTaxes;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.ProjectsSuppliersTaxes;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectsSuppliersTaxes
{
    public class ProjectSupplierTaxeRepository : GenericRepository<ProjectSupplierTaxe>, IProjectSupplierTaxeRepository
    {
        private readonly AIODBContext _db;

        public ProjectSupplierTaxeRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
