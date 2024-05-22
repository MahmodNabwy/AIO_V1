using AIO.Core.Entities.Taxes;
using AIO.Core.IServices.Repositories.Suppliers;
using AIO.Core.IServices.Repositories.Taxes;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Taxes
{
    public class TaxesRepository : GenericRepository<Taxe>, ITaxesRepository
    {
        private readonly AIODBContext _db;
        public TaxesRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
