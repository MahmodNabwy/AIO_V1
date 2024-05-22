using AIO.Contracts.Filters.Auth;
using AIO.Contracts.IServices.Custom;
using Microsoft.AspNetCore.Identity;

namespace AIO.Contracts.IServices.Repositories.Auth
{
    public interface IUserRoleRepository : IGenericRepository<IdentityUserRole<string>>
    {
        public IQueryable<object> buildUserRoleQuery(UserRoleFilter userRoleFilter);
    }
}
