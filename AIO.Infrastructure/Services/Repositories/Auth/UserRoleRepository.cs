using AIO.Contracts.Filters.Auth;
using AIO.Contracts.IServices.Repositories.Auth;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.AspNetCore.Identity;

namespace AIO.Infrastructure.Services.Repositories.Auth
{
    public class UserRoleRepository : GenericRepository<IdentityUserRole<string>>, IUserRoleRepository
    {
        private readonly AIODBContext _db;
        public UserRoleRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }

        public IQueryable<object> buildUserRoleQuery(UserRoleFilter userRoleFilter)
        {
            var query = Query();
            if (userRoleFilter is not null)
            {
                try
                {
                    // Where
                    if (!string.IsNullOrEmpty(userRoleFilter.UserId))
                        query = query.Where(x => x.UserId == userRoleFilter.UserId);

                    if (!string.IsNullOrEmpty(userRoleFilter.RoleId))
                        query = query.Where(x => x.RoleId == userRoleFilter.RoleId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return query;
        }
    }
}
