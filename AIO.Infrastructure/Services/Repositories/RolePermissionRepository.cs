using AIO.Contracts.IServices.Repositories.Auth.Roles;
using AIO.Core.Entities;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories
{
    internal class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        private readonly AIODBContext _db;
        public RolePermissionRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
