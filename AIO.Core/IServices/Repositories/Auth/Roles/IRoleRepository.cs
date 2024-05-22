using AIO.Contracts.Filters.Auth;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Auth.Roles;

namespace AIO.Contracts.IServices.Repositories.Auth.Roles
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public IQueryable<object> buildRoleQuery(RoleFilter roleFilter);
    }
}
