using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.IServices.Repositories.ProjectInsurances;
using AIO.Core.IServices.Repositories.ProjectPaymentMethods;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectPaymentMethods
{
    public class ProjectPaymentMethodRepository : GenericRepository<ProjectPaymentMethod>, IProjectPaymentMethodRepository
    {
        private readonly AIODBContext _db;

        public ProjectPaymentMethodRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
