
using AIO.Core.Entities.Owners;
using AIO.Core.IServices.Repositories.Owners;
using AIO.Core.IServices.Repositories.Suppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Owners
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly AIODBContext _db;
        public OwnerRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
