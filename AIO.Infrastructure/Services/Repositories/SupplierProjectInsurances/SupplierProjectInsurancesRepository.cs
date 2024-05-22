using AIO.Core.Entities.SupplierInsurances;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.SupplierProjectInsurances;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.SupplierProjectInsurances
{
    public class SupplierProjectInsurancesRepository : GenericRepository<SupplierProjectInsurance>, ISupplierProjectInsurancesRepository
    {
        private readonly AIODBContext _db;
        public SupplierProjectInsurancesRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
