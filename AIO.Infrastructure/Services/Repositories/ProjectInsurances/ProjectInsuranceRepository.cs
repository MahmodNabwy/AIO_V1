using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.IServices.Repositories.ProjectInsurances;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectInsurances
{
    public class ProjectInsuranceRepository : GenericRepository<ProjectInsurance>, IProjectInsuranceRepository
    {
        private readonly AIODBContext _db;
        public ProjectInsuranceRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }


    }
}
