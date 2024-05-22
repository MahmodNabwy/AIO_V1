using AIO.Contracts.IServices.Repositories.Auth;
using AIO.Core.Entities;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories
{
    internal class PermissionModuleRepository : GenericRepository<PermissionModule>, IPermissionModuleRepository
    {
        private readonly AIODBContext _db;
        public PermissionModuleRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
